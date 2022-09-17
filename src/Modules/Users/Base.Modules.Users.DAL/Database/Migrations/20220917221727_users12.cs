using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRowVersion",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsRowVersion",
                schema: "users",
                table: "CustomPowers");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "users",
                table: "Users",
                type: "bytea",
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
                values: new object[] { new DateTime(2022, 9, 18, 1, 17, 26, 788, DateTimeKind.Local).AddTicks(5203), "75fdf9ca-0777-4b24-b8b2-88c13186f9a0", "isgRHZOXsjiGjhvh5EchDg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "users",
                table: "CustomPowers");

            migrationBuilder.AddColumn<byte[]>(
                name: "IsRowVersion",
                schema: "users",
                table: "Users",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "IsRowVersion",
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
                values: new object[] { new DateTime(2022, 9, 18, 0, 57, 6, 627, DateTimeKind.Local).AddTicks(259), "6c979df8-74bc-4ff5-afb1-db860884fce6", "OfFgb+9DWqAEX0fkzW56Fw==" });
        }
    }
}
