using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockCaseProject.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ddsfs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ChangeLogs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ChangeLogs");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ChangeLogs");

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 20, 14, 47, 45, 783, DateTimeKind.Local).AddTicks(2784), new DateTime(2022, 12, 20, 14, 47, 45, 783, DateTimeKind.Local).AddTicks(2783) });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 20, 14, 47, 45, 783, DateTimeKind.Local).AddTicks(2786), new DateTime(2022, 12, 20, 14, 47, 45, 783, DateTimeKind.Local).AddTicks(2786) });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 20, 14, 47, 45, 783, DateTimeKind.Local).AddTicks(2788), new DateTime(2022, 12, 20, 14, 47, 45, 783, DateTimeKind.Local).AddTicks(2788) });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 20, 14, 47, 45, 783, DateTimeKind.Local).AddTicks(2790), new DateTime(2022, 12, 20, 14, 47, 45, 783, DateTimeKind.Local).AddTicks(2790) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ChangeLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ChangeLogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ChangeLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9748), new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9748) });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9751), new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9750) });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9753), new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9752) });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9755), new DateTime(2022, 12, 15, 13, 23, 51, 739, DateTimeKind.Local).AddTicks(9754) });
        }
    }
}
