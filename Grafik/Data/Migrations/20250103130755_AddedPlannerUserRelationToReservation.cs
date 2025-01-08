using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grafik.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlannerUserRelationToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlannerUserId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PlannerUserId",
                table: "Reservations",
                column: "PlannerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PlannerUsers_PlannerUserId",
                table: "Reservations",
                column: "PlannerUserId",
                principalTable: "PlannerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PlannerUsers_PlannerUserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PlannerUserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PlannerUserId",
                table: "Reservations");
        }
    }
}
