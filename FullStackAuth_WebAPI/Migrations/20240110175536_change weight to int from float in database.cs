using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeweighttointfromfloatindatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4194871-68a2-4adf-9147-281ef148db99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f168e48e-3b4f-44ed-a116-4c2710e11817");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Dogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8ada7ed8-f18c-4e9c-95ab-9576525ed26b", null, "Admin", "ADMIN" },
                    { "904b48d7-ab1e-44b5-bc96-a88dde8062ed", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ada7ed8-f18c-4e9c-95ab-9576525ed26b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904b48d7-ab1e-44b5-bc96-a88dde8062ed");

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Dogs",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e4194871-68a2-4adf-9147-281ef148db99", null, "User", "USER" },
                    { "f168e48e-3b4f-44ed-a116-4c2710e11817", null, "Admin", "ADMIN" }
                });
        }
    }
}
