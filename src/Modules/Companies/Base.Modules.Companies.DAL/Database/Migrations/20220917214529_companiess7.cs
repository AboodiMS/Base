using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companiess7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "companies",
                table: "ModuleSettings",
                keyColumn: "Code",
                keyValue: "companies-modules");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/GetById");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/UpdateActiveSections");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 18, 0, 45, 28, 796, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/Update",
                column: "DependsOn",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 18, 0, 30, 36, 827, DateTimeKind.Local).AddTicks(9131));

            migrationBuilder.InsertData(
                schema: "companies",
                table: "ModuleSettings",
                columns: new[] { "Code", "Name", "Settings", "Type" },
                values: new object[] { "companies-modules", "Companies Managament", null, null });

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "Code",
                keyValue: "companies-module/Companies/Update",
                column: "DependsOn",
                value: new[] { "companies-module/Companies/GetById" });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "Code", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCode" },
                values: new object[,]
                {
                    { "companies-module/Companies/GetById", null, true, "عرض", 10101, "companies-module/Companies" },
                    { "companies-module/Companies/UpdateActiveSections", new[] { "companies-module/Companies/GetById" }, true, "تعديل", 10103, "companies-module/Companies" }
                });
        }
    }
}
