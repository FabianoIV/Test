using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grafik.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserHourLimitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserHourLimit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanningSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlannerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnavailabilityPaidHoursLimit = table.Column<int>(type: "int", nullable: false),
                    SchooolReunionHoursLimit = table.Column<int>(type: "int", nullable: false),
                    UnavailabilityFreeHoursLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHourLimit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHourLimit_PlannerUsers_PlannerUserId",
                        column: x => x.PlannerUserId,
                        principalTable: "PlannerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHourLimit_PlanningSessions_PlanningSessionId",
                        column: x => x.PlanningSessionId,
                        principalTable: "PlanningSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHourLimit_PlannerUserId",
                table: "UserHourLimit",
                column: "PlannerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHourLimit_PlanningSessionId",
                table: "UserHourLimit",
                column: "PlanningSessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHourLimit");
        }
    }
}
