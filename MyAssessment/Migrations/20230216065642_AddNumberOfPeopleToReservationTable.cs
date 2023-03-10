using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAssessment.Migrations
{
    /// <inheritdoc />
    public partial class AddNumberOfPeopleToReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfPeople",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPeople",
                table: "Reservation");
        }
    }
}
