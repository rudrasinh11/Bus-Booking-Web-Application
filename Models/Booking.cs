using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBookingWebApp.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; } = null!;

        public string CustomerName { get; set; } = string.Empty;
        public int SeatsBooked { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime TravelDate { get; set; }

        public string SelectedSeatNumbers { get; set; } = string.Empty;

        // ✅ NEW: Link to logged-in user
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
