using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 16, 20, 29, 14, 710, DateTimeKind.Local).AddTicks(8101), "98724994-3abe-480e-9d6f-aafbcc4faed3", "/LfZHXyDgUxU1ZQtHPQE5Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 16, 20, 26, 55, 752, DateTimeKind.Local).AddTicks(489), "01edd596-3ebf-4303-aa08-c79512b9dce1", "WTCzTVysUd4iH0ed8thCNw==" });
        }
    }
}
