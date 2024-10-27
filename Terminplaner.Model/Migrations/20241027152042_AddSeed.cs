using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Terminplaner.Model.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("6c7882c9-a14e-4eb8-9377-2b8a7aef4f9c"), "admin@admin.com", "admin", "Administrator", "admin" },
                    { new Guid("b2b76e15-fb17-4c90-bf60-5016b3c7c6df"), "test@test.com", "test", "Employee", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Description", "EndTime", "StartTime", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Scrum daily", new DateTime(2024, 10, 27, 17, 20, 42, 449, DateTimeKind.Local).AddTicks(8711), new DateTime(2024, 10, 27, 16, 20, 42, 449, DateTimeKind.Local).AddTicks(8666), "Scheduled", "Meeting", new Guid("b2b76e15-fb17-4c90-bf60-5016b3c7c6df") },
                    { 2, "Review code with team", new DateTime(2024, 10, 27, 19, 20, 42, 449, DateTimeKind.Local).AddTicks(8720), new DateTime(2024, 10, 27, 18, 20, 42, 449, DateTimeKind.Local).AddTicks(8719), "Scheduled", "Code Review", new Guid("6c7882c9-a14e-4eb8-9377-2b8a7aef4f9c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6c7882c9-a14e-4eb8-9377-2b8a7aef4f9c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2b76e15-fb17-4c90-bf60-5016b3c7c6df"));

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Appointments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
