using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockCaseProject.Repository.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryKeyValue = table.Column<int>(type: "int", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeLogs", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeLogs");

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7949), new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7949) });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7952), new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7951) });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7954), new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7954) });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7957), new DateTime(2022, 12, 6, 6, 13, 5, 720, DateTimeKind.Local).AddTicks(7956) });
        }
    }
}
