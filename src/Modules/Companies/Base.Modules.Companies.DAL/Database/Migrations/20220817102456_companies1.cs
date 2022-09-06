using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.DataBase.Migrations
{
    public partial class companies1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Company_Name",
                schema: "companies",
                table: "Companies");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "companies",
                table: "Companies",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedUserId",
                schema: "companies",
                table: "Companies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "companies",
                table: "Companies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "IsRowVersion",
                schema: "companies",
                table: "Companies",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                schema: "companies",
                table: "Companies",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdateUserId",
                schema: "companies",
                table: "Companies",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "CreatedUserId" },
                values: new object[] { new DateTime(2022, 8, 17, 13, 24, 56, 710, DateTimeKind.Local).AddTicks(8060), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.CreateIndex(
                name: "IX_Company_Name",
                schema: "companies",
                table: "Companies",
                column: "Name",
                unique: true,
                filter: "\"IsDeleted\" = false ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Company_Name",
                schema: "companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                schema: "companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsRowVersion",
                schema: "companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                schema: "companies",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastUpdateUserId",
                schema: "companies",
                table: "Companies");

            migrationBuilder.CreateIndex(
                name: "IX_Company_Name",
                schema: "companies",
                table: "Companies",
                column: "Name",
                unique: true);
        }
    }
}
