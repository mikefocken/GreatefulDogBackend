using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDogEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bfa7727-020c-49cd-abcb-b9e04aa515bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b69ef5ae-9f27-4e20-bc95-ba956b0c1aa3");

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Breed = table.Column<string>(type: "longtext", nullable: true),
                    Gender = table.Column<string>(type: "longtext", nullable: true),
                    Size = table.Column<string>(type: "longtext", nullable: true),
                    Weight = table.Column<float>(type: "float", nullable: false),
                    EnergyLevel = table.Column<string>(type: "longtext", nullable: true),
                    Color = table.Column<string>(type: "longtext", nullable: true),
                    AdoptionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsAdopted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e8a3c14-72a0-4fe9-9f1b-38111ef7cdf1", null, "Admin", "ADMIN" },
                    { "c1886e81-f9e8-4cd1-8eb8-db6366bb8553", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e8a3c14-72a0-4fe9-9f1b-38111ef7cdf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1886e81-f9e8-4cd1-8eb8-db6366bb8553");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bfa7727-020c-49cd-abcb-b9e04aa515bb", null, "Admin", "ADMIN" },
                    { "b69ef5ae-9f27-4e20-bc95-ba956b0c1aa3", null, "User", "USER" }
                });
        }
    }
}
