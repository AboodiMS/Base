using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsRowVersion",
                schema: "users",
                table: "ModuleSettings");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "users",
                table: "CustomPowers");

            migrationBuilder.AlterColumn<uint>(
                name: "xmin",
                schema: "users",
                table: "Users",
                type: "xid",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldRowVersion: true);

            migrationBuilder.AddColumn<long>(
                name: "xmin",
                schema: "users",
                table: "ModuleSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 19, 14, 7, 4, 353, DateTimeKind.Local).AddTicks(5066), "ba4292a7-021f-43a9-9fb2-44314614e087", "+SlKqRU7VtXoAQ+WcbSqcQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "xmin",
                schema: "users",
                table: "ModuleSettings");

            migrationBuilder.AlterColumn<long>(
                name: "xmin",
                schema: "users",
                table: "Users",
                type: "bigint",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "xid",
                oldRowVersion: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "users",
                table: "Users",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "IsRowVersion",
                schema: "users",
                table: "ModuleSettings",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "users",
                table: "CustomPowers",
                type: "bytea",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 22, 13, 45, 626, DateTimeKind.Local).AddTicks(9447), "5198ed0d-f24b-4d8b-adff-3362c682a495", "Hfgww+kFY7eWmKPoGTcozg==" });
        }
    }
}
