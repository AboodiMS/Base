using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "users",
                table: "TreePowers",
                columns: new[] { "CodeName", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCodeName" },
                values: new object[] { "mainroot", null, false, "mainroot", 0, null });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "companies-module",
                column: "ParentCodeName",
                value: "mainroot");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module",
                column: "ParentCodeName",
                value: "mainroot");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "mainroot");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "companies-module",
                column: "ParentCodeName",
                value: null);

            migrationBuilder.UpdateData(
                schema: "users",
                table: "TreePowers",
                keyColumn: "CodeName",
                keyValue: "users-module",
                column: "ParentCodeName",
                value: null);
        }
    }
}
