using Microsoft.EntityFrameworkCore;
using BusBookingWebApp.Models;
using RouteModel = BusBookingWebApp.Models.Route;

namespace BusBookingWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Bus> Buses { get; set; } = default!;
        public DbSet<RouteModel> Routes { get; set; } = default!;
        public DbSet<Seat> Seats { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<Schedule> Schedules { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Composite key for Seat
            modelBuilder.Entity<Seat>().HasKey(s => new { s.BusId, s.SeatNumber });

            // ✅ User-Booking relationship
            modelBuilder.Entity<User>()
                        .HasMany(u => u.Bookings)
                        .WithOne()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

            // ✅ Routes seed data
            modelBuilder.Entity<RouteModel>().HasData(
                new RouteModel { Id = 1, From = "Mumbai", To = "Pune", DistanceKm = 150, DurationHours = 4.5 },
                new RouteModel { Id = 2, From = "Pune", To = "Nashik", DistanceKm = 200, DurationHours = 5 },
                new RouteModel { Id = 3, From = "Nashik", To = "Aurangabad", DistanceKm = 185, DurationHours = 4 },
                new RouteModel { Id = 4, From = "Mumbai", To = "Aurangabad", DistanceKm = 335, DurationHours = 8 },
                new RouteModel { Id = 5, From = "Pune", To = "Aurangabad", DistanceKm = 230, DurationHours = 6 }
            );

            // ✅ Buses seed data
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Bus>().HasData(
                    new Bus
                    {
                        Id = i,
                        Name = $"Bus {i}",
                        RegistrationNumber = $"MH12AB{1000 + i}",
                        TotalSeats = 40 + (i % 5) * 5,
                        BusType = i % 2 == 0 ? "Seater" : "Sleeper",
                        RouteId = (i % 5) + 1
                    }
                );
            }

            // ✅ Schedules seed data
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Schedule>().HasData(
                    new Schedule
                    {
                        Id = i,
                        BusId = i,
                        DepartureTime = new DateTime(2025, 10, 22, 8, 0, 0).AddHours(i - 1),
                        ArrivalTime = new DateTime(2025, 10, 22, 12, 0, 0).AddHours(i - 1),
                        Fare = 400 + (i - 1) * 10
                    }
                );
            }
        }
    }
}
