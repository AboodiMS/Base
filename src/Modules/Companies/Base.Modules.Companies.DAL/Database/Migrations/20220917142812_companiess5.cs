using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companiess5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCodeName",
                schema: "companies",
                table: "TreePowers");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 17, 17, 28, 11, 758, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies",
                column: "ParentCode",
                value: "companies-module");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/GetById",
                column: "ParentCode",
                value: "companies-module/Companies");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/Update",
                column: "ParentCode",
                value: "companies-module/Companies");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/UpdateActiveSections",
                column: "ParentCode",
                value: "companies-module/Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentCodeName",
                schema: "companies",
                table: "TreePowers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 17, 17, 7, 44, 110, DateTimeKind.Local).AddTicks(3446));

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "companies-module" });

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/GetById",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "companies-module/Companies" });

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/Update",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "companies-module/Companies" });

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/UpdateActiveSections",
                columns: new[] { "ParentCode", "ParentCodeName" },
                values: new object[] { null, "companies-module/Companies" });
        }
    }
}
