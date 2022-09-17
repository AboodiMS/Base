using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 19, 14, 29, 46, 787, DateTimeKind.Local).AddTicks(4577), "bed51277-7c99-47e7-84bc-5d7405b0782f", "n9LR71f0DSb3uMgzwSV6Ew==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 19, 14, 7, 4, 353, DateTimeKind.Local).AddTicks(5066), "ba4292a7-021f-43a9-9fb2-44314614e087", "+SlKqRU7VtXoAQ+WcbSqcQ==" });
        }
    }
}
