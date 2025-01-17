using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grafik.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRelationBetweenReservationAndPlannedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PlannerUsers_PlannerUserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PlanningSessions_PlanningSessionId",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlannerUserId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PlannerUsers_PlannerUserId",
                table: "Reservations",
                column: "PlannerUserId",
                principalTable: "PlannerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PlanningSessions_PlanningSessionId",
                table: "Reservations",
                column: "PlanningSessionId",
                principalTable: "PlanningSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PlannerUsers_PlannerUserId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_PlanningSessions_PlanningSessionId",
                table: "Reservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlannerUserId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PlannerUsers_PlannerUserId",
                table: "Reservations",
                column: "PlannerUserId",
                principalTable: "PlannerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_PlanningSessions_PlanningSessionId",
                table: "Reservations",
                column: "PlanningSessionId",
                principalTable: "PlanningSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
