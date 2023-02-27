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
            migrationBuilder.DropColumn(
                name: "Funds",
                table: "Games");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Funds",
                table: "Games",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                columns: new[] { "Date", "Funds" },
                values: new object[] { new DateTime(2023, 2, 18, 22, 58, 7, 80, DateTimeKind.Local).AddTicks(2987), 200.00m });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                columns: new[] { "Date", "Funds" },
                values: new object[] { new DateTime(2023, 2, 18, 22, 58, 7, 80, DateTimeKind.Local).AddTicks(3052), 5000.00m });
        }
    }
}
