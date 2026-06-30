using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationHoursToRoute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DistanceKm",
                table: "Routes",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<double>(
                name: "DurationHours",
                table: "Routes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DistanceKm", "DurationHours" },
                values: new object[] { 150.0, 4.5 });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DistanceKm", "DurationHours" },
                values: new object[] { 200.0, 5.0 });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DistanceKm", "DurationHours" },
                values: new object[] { 185.0, 4.0 });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DistanceKm", "DurationHours" },
                values: new object[] { 335.0, 8.0 });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DistanceKm", "DurationHours" },
                values: new object[] { 230.0, 6.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationHours",
                table: "Routes");

            migrationBuilder.AlterColumn<int>(
                name: "DistanceKm",
                table: "Routes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DistanceKm",
                value: 150);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DistanceKm",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 3,
                column: "DistanceKm",
                value: 185);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 4,
                column: "DistanceKm",
                value: 335);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: 5,
                column: "DistanceKm",
                value: 230);
        }
    }
}
