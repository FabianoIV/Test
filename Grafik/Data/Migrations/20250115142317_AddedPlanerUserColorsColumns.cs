using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grafik.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlanerUserColorsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolReuninionCardColor",
                table: "PlannerUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnavailabilityFreeDayShiftCardColor",
                table: "PlannerUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnavailabilityFreeNightShiftCardColor",
                table: "PlannerUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnavailabilityPaidCardColor",
                table: "PlannerUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolReuninionCardColor",
                table: "PlannerUsers");

            migrationBuilder.DropColumn(
                name: "UnavailabilityFreeDayShiftCardColor",
                table: "PlannerUsers");

            migrationBuilder.DropColumn(
                name: "UnavailabilityFreeNightShiftCardColor",
                table: "PlannerUsers");

            migrationBuilder.DropColumn(
                name: "UnavailabilityPaidCardColor",
                table: "PlannerUsers");
        }
    }
}
