namespace BusBookingWebApp.Models;

public class Seat
{
    public int BusId { get; set; }
    public int SeatNumber { get; set; }
    public bool IsAvailable { get; set; }

    public Bus? Bus { get; set; }
}
