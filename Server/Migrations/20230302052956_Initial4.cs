using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fairSlots.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chances",
                columns: table => new
                {
                    ChanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chances", x => x.ChanceID);
                    table.ForeignKey(
                        name: "FK_Chances_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chances",
                columns: new[] { "ChanceID", "PlayerID", "UpdateTime", "WinRate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 1, 21, 29, 56, 592, DateTimeKind.Local).AddTicks(4059), 0.30m },
                    { 2, 3, new DateTime(2023, 3, 1, 21, 29, 56, 592, DateTimeKind.Local).AddTicks(4065), 0.27m }
                });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 1, 21, 29, 56, 592, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameID",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 1, 21, 29, 56, 592, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.CreateIndex(
                name: "IX_Chances_PlayerID",
                table: "Chances",
                column: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chances");

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
    }
}
