namespace BusBookingWebApp.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public double DurationHours { get; set; } // e.g. 8.5 for 8h 30m
        public double DistanceKm { get; set; }
    }
}
