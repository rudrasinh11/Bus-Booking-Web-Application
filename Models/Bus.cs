using System.Collections.Generic;

namespace BusBookingWebApp.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string BusType { get; set; } = "Seater";
        public int TotalSeats { get; set; }

        // Foreign key to Route
        public int RouteId { get; set; }
        public Route? Route { get; set; }

        // Navigation property to Schedule
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
