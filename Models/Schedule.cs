using System;
using System.Collections.Generic;
using BusBookingWebApp.Models; // ✅ ensures Booking and Bus are visible

namespace BusBookingWebApp.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        // Foreign key
        public int BusId { get; set; }

        // Navigation property
        public Bus Bus { get; set; } = null!;

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Fare { get; set; }

        // Navigation property for related bookings
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
