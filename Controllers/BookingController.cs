using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusBookingWebApp.Data;
using BusBookingWebApp.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingWebApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookingController(ApplicationDbContext db) => _db = db;

        // =======================
        // GET: Seat Booking Page
        // =======================
        [HttpGet]
        public IActionResult Book(int scheduleId, DateTime? travelDate)
        {
            var schedule = _db.Schedules
                .Include(s => s.Bus)
                    .ThenInclude(b => b.Route)
                .Include(s => s.Bookings)
                .FirstOrDefault(s => s.Id == scheduleId);

            if (schedule == null)
                return NotFound();

            var chosenDate = travelDate?.Date ?? schedule.DepartureTime.Date;

            var bookedSeats = _db.Bookings
                .Where(b => b.ScheduleId == scheduleId && b.TravelDate == chosenDate)
                .AsEnumerable()
                .SelectMany(b => (b.SelectedSeatNumbers ?? "")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Select(x => int.TryParse(x.Trim(), out var n) ? n : 0)
                .Where(n => n > 0)
                .ToList();

            ViewBag.BookedSeats = bookedSeats;
            ViewBag.TotalSeats = schedule.Bus?.TotalSeats ?? 40;
            ViewBag.Schedule = schedule;
            ViewBag.TravelDate = chosenDate.ToString("yyyy-MM-dd");

            return View(schedule);
        }

        // =======================
        // POST: Confirm Booking
        // =======================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(int scheduleId, string customerName, DateTime travelDate, string selectedSeatsCsv)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                return BadRequest("Invalid customer name.");

            var schedule = _db.Schedules
                .Include(s => s.Bus)
                .FirstOrDefault(s => s.Id == scheduleId);

            if (schedule == null)
                return NotFound();

            var selectedSeats = selectedSeatsCsv?
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.TryParse(s.Trim(), out var n) ? n : 0)
                .Where(n => n > 0)
                .Distinct()
                .ToList() ?? new List<int>();

            if (!selectedSeats.Any())
                return BadRequest("Please select at least one seat.");

            var totalSeats = schedule.Bus?.TotalSeats ?? 40;
            if (selectedSeats.Any(s => s > totalSeats))
                return BadRequest("Selected seat number is invalid.");

            var alreadyBooked = _db.Bookings
                .Where(b => b.ScheduleId == scheduleId && b.TravelDate == travelDate.Date)
                .AsEnumerable()
                .SelectMany(b => (b.SelectedSeatNumbers ?? "")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries))
                .Select(s => int.TryParse(s, out var n) ? n : 0)
                .Where(n => n > 0)
                .ToHashSet();

            var conflict = selectedSeats.FirstOrDefault(s => alreadyBooked.Contains(s));
            if (conflict != 0)
                return BadRequest($"Seat {conflict} is already booked for {travelDate:yyyy-MM-dd}.");

            var booking = new Booking
            {
                ScheduleId = scheduleId,
                CustomerName = customerName.Trim(),
                SeatsBooked = selectedSeats.Count,
                BookingTime = DateTime.Now,
                TravelDate = travelDate.Date,
                SelectedSeatNumbers = string.Join(",", selectedSeats.OrderBy(x => x))
            };

            _db.Bookings.Add(booking);
            _db.SaveChanges();

            return RedirectToAction("Confirmation", new { bookingId = booking.Id });
        }

        // =======================
        // GET: Booking Confirmation
        // =======================
        [HttpGet]
        public IActionResult Confirmation(int bookingId)
        {
            var booking = _db.Bookings
                .Include(b => b.Schedule)
                    .ThenInclude(s => s.Bus)
                        .ThenInclude(bus => bus.Route)
                .FirstOrDefault(b => b.Id == bookingId);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // =======================
        // GET: Download Ticket (PDF)
        // =======================
        [HttpGet]
        public IActionResult DownloadTicket(int bookingId)
        {
            var booking = _db.Bookings
                .Include(b => b.Schedule)
                    .ThenInclude(s => s.Bus)
                        .ThenInclude(bus => bus.Route)
                .FirstOrDefault(b => b.Id == bookingId);

            if (booking == null)
                return NotFound();

            var schedule = booking.Schedule;
            var bus = schedule?.Bus;
            var route = bus?.Route;

            var farePerSeat = schedule?.Fare ?? 0m;
            var totalAmount = farePerSeat * booking.SeatsBooked;

            using (var ms = new MemoryStream())
            {
                var doc = new Document(PageSize.A4, 50, 50, 50, 50);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var labelFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                doc.Add(new Paragraph("🚌 Bus Ticket", titleFont));
                doc.Add(new Paragraph("------------------------------------------------------------"));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph($"Passenger Name: {booking.CustomerName}", normalFont));
                doc.Add(new Paragraph($"Route: {route?.From ?? "N/A"} → {route?.To ?? "N/A"}", normalFont));
                doc.Add(new Paragraph($"Travel Date: {booking.TravelDate:dd MMM yyyy}", normalFont));
                doc.Add(new Paragraph($"Departure: {schedule?.DepartureTime:hh:mm tt}", normalFont));
                doc.Add(new Paragraph($"Bus: {bus?.Name ?? "N/A"}", normalFont));
                doc.Add(new Paragraph($"Seats: {booking.SeatsBooked}", normalFont));
                doc.Add(new Paragraph($"Seat Numbers: {booking.SelectedSeatNumbers}", normalFont));
                doc.Add(new Paragraph("\n"));
                doc.Add(new Paragraph($"Fare per Seat: ₹{farePerSeat}", normalFont));
                doc.Add(new Paragraph($"Total Fare: ₹{totalAmount}", labelFont));
                doc.Add(new Paragraph("\n------------------------------------------------------------\n"));
                doc.Add(new Paragraph("Thank you for booking with BusBookingWebApp!", labelFont));
                doc.Add(new Paragraph($"\nGenerated On: {DateTime.Now:dd MMM yyyy, hh:mm tt}", normalFont));
                doc.Close();

                return File(ms.ToArray(), "application/pdf", $"Ticket_{booking.Id}.pdf");
            }
        }

        // =======================
        // GET: My Bookings
        // =======================
        [HttpGet]
        public async Task<IActionResult> MyBookings()
        {
            var bookings = await _db.Bookings
                .Include(b => b.Schedule)
                    .ThenInclude(s => s.Bus)
                        .ThenInclude(b => b.Route)
                .OrderByDescending(b => b.BookingTime)
                .ToListAsync();

            return View(bookings);
        }

        // =======================
        // POST: Cancel Booking
        // =======================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var booking = await _db.Bookings.FindAsync(id);
            if (booking == null)
                return NotFound();

            _db.Bookings.Remove(booking);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(MyBookings));
        }
    }
}
