using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fairSlots.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 28, 16, 37, 38, 138, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 2, 28, 16, 37, 38, 138, DateTimeKind.Local).AddTicks(9139));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 18, 22, 58, 7, 80, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 2, 18, 22, 58, 7, 80, DateTimeKind.Local).AddTicks(3052));
        }
    }
}
