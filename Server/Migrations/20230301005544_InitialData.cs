using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fairSlots.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 28, 16, 55, 43, 976, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 2, 28, 16, 55, 43, 976, DateTimeKind.Local).AddTicks(9137));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 28, 16, 49, 44, 856, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 2, 28, 16, 49, 44, 856, DateTimeKind.Local).AddTicks(4335));
        }
    }
}
