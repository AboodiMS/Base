using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 1, 19, 43, 10, DateTimeKind.Local).AddTicks(1617), "6ff8366e-1720-4ae1-b5ad-802f19284f5a", "8r9Cc81A9nrJVbPok9NeJw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 1, 17, 26, 788, DateTimeKind.Local).AddTicks(5203), "75fdf9ca-0777-4b24-b8b2-88c13186f9a0", "isgRHZOXsjiGjhvh5EchDg==" });
        }
    }
}
