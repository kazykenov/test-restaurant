using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAssessment.Migrations
{
    /// <inheritdoc />
    public partial class AlterReservationDateToTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Reservation");

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Reservation",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Reservation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Hour",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
