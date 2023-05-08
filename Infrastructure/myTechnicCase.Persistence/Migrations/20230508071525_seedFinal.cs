using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace myTechnicCase.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "EndDate", "Name", "StartDate", "TeamId", "Type" },
                values: new object[,]
                {
                    { 111, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morning Shift", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Half Time" },
                    { 222, new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Night Shift", new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Full Time" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name", "SupervisorPersonnelId" },
                values: new object[] { 3, "C Team", 31 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
