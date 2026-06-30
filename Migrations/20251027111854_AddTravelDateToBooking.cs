using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTravelDateToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TravelDate",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TravelDate",
                table: "Bookings");
        }
    }
}
