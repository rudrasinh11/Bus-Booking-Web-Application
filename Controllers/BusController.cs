using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusBookingWebApp.Data;
using BusBookingWebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingWebApp.Controllers
{
    public class BusController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BusController(ApplicationDbContext db) => _db = db;

        // ✅ Only logged-in users can access the Bus List page
        public async Task<IActionResult> List(string from, string to)
        {
            // 🔐 Check if user is logged in
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                // Save current URL so user can return after login
                TempData["ReturnUrl"] = Url.Action("List", "Bus", new { from, to });
                return RedirectToAction("Login", "Account");
            }

            var schedules = _db.Schedules
                .Include(s => s.Bus)
                    .ThenInclude(b => b.Route)
                .Include(s => s.Bookings)
                .AsQueryable();

            if (!string.IsNullOrEmpty(from))
            {
                from = from.ToLower().Trim();
                schedules = schedules.Where(s =>
                    s.Bus != null &&
                    s.Bus.Route != null &&
                    s.Bus.Route.From.ToLower().Contains(from)
                );
            }

            if (!string.IsNullOrEmpty(to))
            {
                to = to.ToLower().Trim();
                schedules = schedules.Where(s =>
                    s.Bus != null &&
                    s.Bus.Route != null &&
                    s.Bus.Route.To.ToLower().Contains(to)
                );
            }

            schedules = schedules.OrderBy(s => s.DepartureTime);
            var result = await schedules.ToListAsync();

            return View(result);
        }
    }
}
