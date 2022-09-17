using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "users",
                table: "CustomPowers");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                schema: "users",
                table: "Users",
                type: "timestamp with time zone",
                rowVersion: true,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                schema: "users",
                table: "CustomPowers",
                type: "timestamp with time zone",
                rowVersion: true,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 1, 41, 14, 325, DateTimeKind.Local).AddTicks(4607), "99913ecf-47b4-4012-b2c9-fd1d54291018", "+SrjxYyYLj/O/VJq9Zb88A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                schema: "users",
                table: "CustomPowers");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "users",
                table: "Users",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "users",
                table: "CustomPowers",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 18, 1, 19, 43, 10, DateTimeKind.Local).AddTicks(1617), "6ff8366e-1720-4ae1-b5ad-802f19284f5a", "8r9Cc81A9nrJVbPok9NeJw==" });
        }
    }
}
