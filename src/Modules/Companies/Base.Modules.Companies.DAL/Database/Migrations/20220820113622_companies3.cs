using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companies3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module/Users/Add");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module/Users/ChangePowers");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module/Users/Delete");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module/Users/GetAll");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module/Users/GetById");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module/Users/Update");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module/Users");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 20, 14, 36, 22, 683, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[] { "companies-module", null, false, "قسم الشركة", 1, null });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[] { "companies-module/Companies", null, false, "معلومات الشركة", 101, "companies-module" });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[,]
                {
                    { "companies-module/Companies/GetById", null, true, "عرض", 10101, "companies-module/Companies" },
                    { "companies-module/Companies/Update", new[] { "companies-module/Companies/GetById" }, true, "تعديل", 10102, "companies-module/Companies" },
                    { "companies-module/Companies/UpdateActiveSections", new[] { "companies-module/Companies/GetById" }, true, "تعديل", 10103, "companies-module/Companies" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "companies-module/Companies/GetById");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "companies-module/Companies/Update");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "companies-module/Companies/UpdateActiveSections");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "companies-module/Companies");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "companies-module");

            migrationBuilder.UpdateData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2022, 8, 20, 14, 28, 12, 293, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[] { "users-module", null, false, "قسم المستخدمين", 1, null });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[] { "users-module/Users", null, false, "معلومات المستخدمين", 101, "users-module" });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[,]
                {
                    { "users-module/Users/Add", null, true, "اضافة", 10103, "users-module/Users" },
                    { "users-module/Users/ChangePowers", new[] { "users-module/Users/GetById" }, true, "تعديل الصلاحيات", 10106, "users-module/Users" },
                    { "users-module/Users/Delete", new[] { "users-module/Users/GetById" }, true, "حذف", 10105, "users-module/Users" },
                    { "users-module/Users/GetAll", null, true, "عرض الكل", 10101, "users-module/Users" },
                    { "users-module/Users/GetById", null, true, "عرض", 10102, "users-module/Users" },
                    { "users-module/Users/Update", new[] { "users-module/Users/GetById" }, true, "تعديل", 10104, "users-module/Users" }
                });
        }
    }
}
