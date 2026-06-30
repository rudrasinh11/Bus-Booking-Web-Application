using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusBookingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Seed20BusesWithFixedDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Routes_RouteId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_RouteId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Schedules");

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BusType", "Name", "RegistrationNumber", "RouteId", "TotalSeats" },
                values: new object[] { "Sleeper", "Bus 1", "MH12AB1001", 1, 45 });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "BusType", "Name", "RegistrationNumber", "RouteId", "TotalSeats" },
                values: new object[,]
                {
                    { 5, "Sleeper", "Bus 5", "MH12AB1005", 1, 40 },
                    { 10, "Seater", "Bus 10", "MH12AB1010", 1, 40 },
                    { 15, "Sleeper", "Bus 15", "MH12AB1015", 1, 40 },
                    { 20, "Seater", "Bus 20", "MH12AB1020", 1, 40 }
                });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DistanceKm", "From", "To" },
                values: new object[] { 150, "Mumbai", "Pune" });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "DistanceKm", "From", "To" },
                values: new object[,]
                {
                    { 2, 200, "Pune", "Nashik" },
                    { 3, 185, "Nashik", "Aurangabad" },
                    { 4, 335, "Mumbai", "Aurangabad" },
                    { 5, 230, "Pune", "Aurangabad" }
                });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime", "Fare" },
                values: new object[] { new DateTime(2025, 10, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 400m });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "BusType", "Name", "RegistrationNumber", "RouteId", "TotalSeats" },
                values: new object[,]
                {
                    { 2, "Seater", "Bus 2", "MH12AB1002", 3, 50 },
                    { 3, "Sleeper", "Bus 3", "MH12AB1003", 4, 55 },
                    { 4, "Seater", "Bus 4", "MH12AB1004", 5, 60 },
                    { 6, "Seater", "Bus 6", "MH12AB1006", 2, 45 },
                    { 7, "Sleeper", "Bus 7", "MH12AB1007", 3, 50 },
                    { 8, "Seater", "Bus 8", "MH12AB1008", 4, 55 },
                    { 9, "Sleeper", "Bus 9", "MH12AB1009", 5, 60 },
                    { 11, "Sleeper", "Bus 11", "MH12AB1011", 2, 45 },
                    { 12, "Seater", "Bus 12", "MH12AB1012", 3, 50 },
                    { 13, "Sleeper", "Bus 13", "MH12AB1013", 4, 55 },
                    { 14, "Seater", "Bus 14", "MH12AB1014", 5, 60 },
                    { 16, "Seater", "Bus 16", "MH12AB1016", 2, 45 },
                    { 17, "Sleeper", "Bus 17", "MH12AB1017", 3, 50 },
                    { 18, "Seater", "Bus 18", "MH12AB1018", 4, 55 },
                    { 19, "Sleeper", "Bus 19", "MH12AB1019", 5, 60 }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "ArrivalTime", "BusId", "DepartureTime", "Fare" },
                values: new object[,]
                {
                    { 5, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2025, 10, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), 440m },
                    { 10, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 10, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 490m },
                    { 15, new DateTime(2025, 10, 23, 2, 0, 0, 0, DateTimeKind.Unspecified), 15, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), 540m },
                    { 20, new DateTime(2025, 10, 23, 7, 0, 0, 0, DateTimeKind.Unspecified), 20, new DateTime(2025, 10, 23, 3, 0, 0, 0, DateTimeKind.Unspecified), 590m },
                    { 2, new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 10, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), 410m },
                    { 3, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2025, 10, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 4, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2025, 10, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 430m },
                    { 6, new DateTime(2025, 10, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2025, 10, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), 450m },
                    { 7, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2025, 10, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), 460m },
                    { 8, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2025, 10, 22, 15, 0, 0, 0, DateTimeKind.Unspecified), 470m },
                    { 9, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2025, 10, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), 480m },
                    { 11, new DateTime(2025, 10, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), 11, new DateTime(2025, 10, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 12, new DateTime(2025, 10, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), 12, new DateTime(2025, 10, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 510m },
                    { 13, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, new DateTime(2025, 10, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), 520m },
                    { 14, new DateTime(2025, 10, 23, 1, 0, 0, 0, DateTimeKind.Unspecified), 14, new DateTime(2025, 10, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 530m },
                    { 16, new DateTime(2025, 10, 23, 3, 0, 0, 0, DateTimeKind.Unspecified), 16, new DateTime(2025, 10, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), 550m },
                    { 17, new DateTime(2025, 10, 23, 4, 0, 0, 0, DateTimeKind.Unspecified), 17, new DateTime(2025, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 560m },
                    { 18, new DateTime(2025, 10, 23, 5, 0, 0, 0, DateTimeKind.Unspecified), 18, new DateTime(2025, 10, 23, 1, 0, 0, 0, DateTimeKind.Unspecified), 570m },
                    { 19, new DateTime(2025, 10, 23, 6, 0, 0, 0, DateTimeKind.Unspecified), 19, new DateTime(2025, 10, 23, 2, 0, 0, 0, DateTimeKind.Unspecified), 580m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Schedules",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Buses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BusType", "Name", "RegistrationNumber", "RouteId", "TotalSeats" },
                values: new object[] { "Seater", "Blue Express", "MH12AB1234", 1, 40 });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DistanceKm", "From", "To" },
                values: new object[] { 120, "CityA", "CityB" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "DepartureTime", "Fare", "RouteId" },
                values: new object[] { new DateTime(2025, 10, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), 499m, null });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RouteId",
                table: "Schedules",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Routes_RouteId",
                table: "Schedules",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }
    }
}
