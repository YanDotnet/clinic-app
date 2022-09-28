using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleService.Infrastructure.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Time_End",
                table: "Registrations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Time_Start",
                table: "Registrations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableTime_End",
                table: "Days",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableTime_Start",
                table: "Days",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time_End",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Time_Start",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "AvailableTime_End",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "AvailableTime_Start",
                table: "Days");
        }
    }
}
