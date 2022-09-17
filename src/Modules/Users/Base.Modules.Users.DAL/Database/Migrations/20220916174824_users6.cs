using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword", "Powers" },
                values: new object[] { new DateTime(2022, 9, 16, 20, 48, 24, 180, DateTimeKind.Local).AddTicks(7091), "cf7aa28d-6735-424e-97b5-e7b772b997e6", "tse8w6UKb8OWmKkuWwSIOg==", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword", "Powers" },
                values: new object[] { new DateTime(2022, 9, 16, 20, 29, 14, 710, DateTimeKind.Local).AddTicks(8101), "98724994-3abe-480e-9d6f-aafbcc4faed3", "/LfZHXyDgUxU1ZQtHPQE5Q==", null });
        }
    }
}
