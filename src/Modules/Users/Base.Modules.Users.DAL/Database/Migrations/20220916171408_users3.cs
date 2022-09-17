using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "Powers",
                schema: "users",
                table: "Users",
                type: "jsonb",
                nullable: true,
                defaultValue: null,
                oldClrType: typeof(string[]),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.AlterColumn<string[]>(
                name: "Powers",
                schema: "users",
                table: "CustomPowers",
                type: "jsonb",
                nullable: true,
                defaultValue: null,
                oldClrType: typeof(string[]),
                oldType: "jsonb",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword", "Powers" },
                values: new object[] { new DateTime(2022, 9, 16, 20, 14, 8, 285, DateTimeKind.Local).AddTicks(3134), "f8ff3025-d2de-42f7-b49c-c567e4b21e3c", "/zM+OqJfSdXvA2Br34PVkg==", new string[0] });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedDate", "HashCode", "HashPassword", "Powers" },
                values: new object[] { new DateTime(2022, 9, 16, 0, 39, 41, 523, DateTimeKind.Local).AddTicks(8491), "daefa1c4-3a76-4840-a865-c00e213017fc", "9TaWnWyfbOpW8mvMt8phgA==", null });
        }
    }
}
