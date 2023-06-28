using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.API.Migrations
{
    /// <inheritdoc />
    public partial class ProductEntityAndSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "PurchaseDate", "Status", "Type", "Value" },
                values: new object[,]
                {
                    { 1L, "Terrain in Medellín", new DateTime(2023, 6, 27, 9, 37, 45, 799, DateTimeKind.Local).AddTicks(5399), false, 2, 60000000L },
                    { 2L, "Libero 125cc", new DateTime(2023, 6, 27, 9, 37, 45, 799, DateTimeKind.Local).AddTicks(5410), false, 1, 4000000L },
                    { 3L, "Aparment in Itagüí", new DateTime(2023, 6, 27, 9, 37, 45, 799, DateTimeKind.Local).AddTicks(5411), false, 3, 59000000L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
