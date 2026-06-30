using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSelectedSeatNumbersToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedSeatNumbers",
                table: "Bookings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedSeatNumbers",
                table: "Bookings");
        }
    }
}
