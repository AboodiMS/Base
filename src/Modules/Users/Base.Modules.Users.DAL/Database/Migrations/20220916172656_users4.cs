using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "Powers",
                schema: "users",
                table: "Users",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "jsonb");

            migrationBuilder.AlterColumn<string[]>(
                name: "Powers",
                schema: "users",
                table: "CustomPowers",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "jsonb");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 16, 20, 26, 55, 752, DateTimeKind.Local).AddTicks(489), "01edd596-3ebf-4303-aa08-c79512b9dce1", "WTCzTVysUd4iH0ed8thCNw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "Powers",
                schema: "users",
                table: "Users",
                type: "jsonb",
                nullable: false,
                defaultValue: null,
                oldClrType: typeof(string[]),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<string[]>(
                name: "Powers",
                schema: "users",
                table: "CustomPowers",
                type: "jsonb",
                nullable: false,
                defaultValue: null,
                oldClrType: typeof(string[]),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 16, 20, 14, 8, 285, DateTimeKind.Local).AddTicks(3134), "f8ff3025-d2de-42f7-b49c-c567e4b21e3c", "/zM+OqJfSdXvA2Br34PVkg==" });
        }
    }
}
