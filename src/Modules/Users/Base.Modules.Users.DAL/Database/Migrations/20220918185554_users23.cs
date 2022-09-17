using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 21, 55, 54, 213, DateTimeKind.Local).AddTicks(3168), "362b8d32-89a1-40e0-8598-43996581231f", "N1ci4d+2oz4lwpxUpNlZsw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 21, 55, 18, 446, DateTimeKind.Local).AddTicks(5567), "feebd775-acdf-4a5d-88e7-98b3054c72ba", "brNVDIbLHjURngBpP1hCXQ==" });
        }
    }
}
