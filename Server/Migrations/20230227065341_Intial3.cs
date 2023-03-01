using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fairSlots.Server.Migrations
{
    /// <inheritdoc />
    public partial class Intial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 26, 22, 53, 41, 366, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 2, 26, 22, 53, 41, 366, DateTimeKind.Local).AddTicks(9337));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 26, 14, 30, 25, 70, DateTimeKind.Local).AddTicks(1212));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 2, 26, 14, 30, 25, 70, DateTimeKind.Local).AddTicks(1374));
        }
    }
}
