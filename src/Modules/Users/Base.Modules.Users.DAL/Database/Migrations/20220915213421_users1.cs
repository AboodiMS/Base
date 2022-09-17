using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodeName",
                schema: "users",
                table: "ModuleSettings",
                newName: "Code");

            migrationBuilder.CreateTable(
                name: "Properties",
                schema: "users",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<string>(type: "jsonb", nullable: true),
                    IsRowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Code);
                });

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 9, 16, 0, 34, 21, 295, DateTimeKind.Local).AddTicks(6406), "671a82e9-93be-4ad1-898f-bdfe579c10b3", "zie8v2dG3rMSSeYsx36JMg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties",
                schema: "users");

            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "users",
                table: "ModuleSettings",
                newName: "CodeName");

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new DateTime(2022, 8, 23, 13, 51, 48, 227, DateTimeKind.Local).AddTicks(2029), "28cfd411-cce7-439a-98a8-60226254f9db", "eA451gAPvpnc3VuHEvPgbA==" });
        }
    }
}
