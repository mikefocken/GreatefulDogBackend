using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeweightfromfloattoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ada7ed8-f18c-4e9c-95ab-9576525ed26b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904b48d7-ab1e-44b5-bc96-a88dde8062ed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e408dd6-c643-4027-92de-7dbaf4a4ad18", null, "User", "USER" },
                    { "a1b8fe34-c30c-4e21-a72d-421934d162b9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e408dd6-c643-4027-92de-7dbaf4a4ad18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1b8fe34-c30c-4e21-a72d-421934d162b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8ada7ed8-f18c-4e9c-95ab-9576525ed26b", null, "Admin", "ADMIN" },
                    { "904b48d7-ab1e-44b5-bc96-a88dde8062ed", null, "User", "USER" }
                });
        }
    }
}
