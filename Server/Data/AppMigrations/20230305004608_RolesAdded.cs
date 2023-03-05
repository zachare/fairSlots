using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fairSlots.Server.Data.AppMigrations
{
    /// <inheritdoc />
    public partial class RolesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "364ca874-4cd8-4ca3-8384-998eeb0cb8c0", null, "User", "USER" },
                    { "4ba051c6-8b9c-48f0-91eb-96e9451fdcf1", null, "Manager", "MANAGER" },
                    { "c58eaf69-9c07-408b-b428-3dc1ac1b03cd", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "364ca874-4cd8-4ca3-8384-998eeb0cb8c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ba051c6-8b9c-48f0-91eb-96e9451fdcf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c58eaf69-9c07-408b-b428-3dc1ac1b03cd");
        }
    }
}
