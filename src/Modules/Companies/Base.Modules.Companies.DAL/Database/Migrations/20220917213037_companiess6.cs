using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    public partial class companiess6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties",
                schema: "companies");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.RenameColumn(
                name: "Setting",
                schema: "companies",
                table: "ModuleSettings",
                newName: "Settings");

            migrationBuilder.AddColumn<byte[]>(
                name: "IsRowVersion",
                schema: "companies",
                table: "ModuleSettings",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "companies",
                table: "ModuleSettings",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActionLogger",
                schema: "companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Table = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<object>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogger",
                schema: "companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Table = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<object>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogger", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "Companies",
                columns: new[] { "Id", "ActiveSections", "CompanyWork", "CreatedDate", "CreatedUserId", "LastUpdateDate", "LastUpdateUserId", "Name" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new[] { "Accounting" }, "", new DateTime(2022, 9, 18, 0, 30, 36, 827, DateTimeKind.Local).AddTicks(9131), new Guid("11111111-1111-1111-1111-111111111111"), null, null, "اسم الشركة" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogger",
                schema: "companies");

            migrationBuilder.DropTable(
                name: "ErrorLogger",
                schema: "companies");

            migrationBuilder.DeleteData(
                schema: "companies",
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DropColumn(
                name: "IsRowVersion",
                schema: "companies",
                table: "ModuleSettings");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "companies",
                table: "ModuleSettings");

            migrationBuilder.RenameColumn(
                name: "Settings",
                schema: "companies",
                table: "ModuleSettings",
                newName: "Setting");

            migrationBuilder.CreateTable(
                name: "Properties",
                schema: "companies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<string>(type: "jsonb", nullable: true),
                    IsRowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Code);
                });

            migrationBuilder.InsertData(
                schema: "companies",
                table: "Companies",
                columns: new[] { "Id", "ActiveSections", "CompanyWork", "CreatedDate", "CreatedUserId", "IsDeleted", "LastUpdateDate", "LastUpdateUserId", "Name" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new[] { "Accounting" }, "", new DateTime(2022, 9, 17, 17, 28, 11, 758, DateTimeKind.Local).AddTicks(8747), new Guid("11111111-1111-1111-1111-111111111111"), false, null, null, "اسم الشركة" });
        }
    }
}
