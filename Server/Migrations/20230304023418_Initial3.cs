using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fairSlots.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Funds = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "Chances",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID1 = table.Column<int>(type: "int", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chances", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Chances_Players_PlayerID1",
                        column: x => x.PlayerID1,
                        principalTable: "Players",
                        principalColumn: "PlayerID");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Win = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                    table.ForeignKey(
                        name: "FK_Games_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chances",
                columns: new[] { "PlayerID", "PlayerID1", "UpdateTime", "WinRate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 3, 3, 18, 34, 17, 830, DateTimeKind.Local).AddTicks(522), 0.30m },
                    { 3, null, new DateTime(2023, 3, 3, 18, 34, 17, 830, DateTimeKind.Local).AddTicks(525), 0.27m }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Funds", "Username" },
                values: new object[,]
                {
                    { 1, 200.00m, "Zach" },
                    { 2, 5000.00m, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "BetAmount", "Date", "PlayerID", "Win" },
                values: new object[,]
                {
                    { 1, 20.00m, new DateTime(2023, 3, 3, 18, 34, 17, 830, DateTimeKind.Local).AddTicks(329), 1, true },
                    { 2, 50.00m, new DateTime(2023, 3, 3, 18, 34, 17, 830, DateTimeKind.Local).AddTicks(484), 2, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chances_PlayerID1",
                table: "Chances",
                column: "PlayerID1");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerID",
                table: "Games",
                column: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chances");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
