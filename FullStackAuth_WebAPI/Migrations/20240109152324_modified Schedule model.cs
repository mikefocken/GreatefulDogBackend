using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class modifiedSchedulemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9558269f-ef1e-4425-8148-b0033eb33d9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2326129-b59e-4c6b-97e2-49f1eca84e5d");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Schedules",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14361951-358a-40d7-ace5-1f7a631faf07", null, "User", "USER" },
                    { "4f96e2db-31dd-40c0-80a9-e5e5a3cee5c5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DogId",
                table: "Schedules",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_AspNetUsers_UserId",
                table: "Schedules",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Dogs_DogId",
                table: "Schedules",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AspNetUsers_UserId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Dogs_DogId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_DogId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14361951-358a-40d7-ace5-1f7a631faf07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f96e2db-31dd-40c0-80a9-e5e5a3cee5c5");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Schedules",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9558269f-ef1e-4425-8148-b0033eb33d9c", null, "Admin", "ADMIN" },
                    { "f2326129-b59e-4c6b-97e2-49f1eca84e5d", null, "User", "USER" }
                });
        }
    }
}
