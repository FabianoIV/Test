using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grafik.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewColumnsToUserHourLimitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnavailabilityFreeHoursInRowLimit",
                table: "UserHourLimit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnavailabilityPaidHoursInRowLimit",
                table: "UserHourLimit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnavailabilityFreeHoursInRowLimit",
                table: "UserHourLimit");

            migrationBuilder.DropColumn(
                name: "UnavailabilityPaidHoursInRowLimit",
                table: "UserHourLimit");
        }
    }
}
