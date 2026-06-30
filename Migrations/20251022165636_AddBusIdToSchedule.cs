using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddBusIdToSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Schedules",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                column: "RouteId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RouteId",
                table: "Schedules",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Routes_RouteId",
                table: "Schedules",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Routes_RouteId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_RouteId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Schedules");
        }
    }
}
