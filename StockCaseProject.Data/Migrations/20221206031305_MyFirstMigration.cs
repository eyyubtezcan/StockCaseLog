using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockCaseProject.Repository.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CreatedDate", "IsActive", "ProductCode", "Quantiy", "UpdatedDate", "VariantCode" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7949), true, "001AD", 120, new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7949), "454CAS" },
                    { 2, new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7952), true, "321AD", 220, new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7951), "DFD545S" },
                    { 3, new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7954), true, "00FF1AD", 67, new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7954), "3234FSF" },
                    { 4, new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7957), true, "ASDFBV443", 6, new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7956), "GFHGFX4363" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
