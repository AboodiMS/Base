using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties",
                schema: "users");

            migrationBuilder.RenameColumn(
                name: "Setting",
                schema: "users",
                table: "ModuleSettings",
                newName: "Settings");

            migrationBuilder.AddColumn<byte[]>(
                name: "IsRowVersion",
                schema: "users",
                table: "ModuleSettings",
                type: "bytea",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "users",
                table: "ModuleSettings",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActionLogger",
                schema: "users",
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
                schema: "users",
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

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "BusinessId", "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2022, 9, 18, 0, 31, 15, 384, DateTimeKind.Local).AddTicks(3955), "7b8fb66c-61c0-4d1e-8440-ab64be4c0b38", "hWsYyefQ4m2oVkXrl4AxbA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogger",
                schema: "users");

            migrationBuilder.DropTable(
                name: "ErrorLogger",
                schema: "users");

            migrationBuilder.DropColumn(
                name: "IsRowVersion",
                schema: "users",
                table: "ModuleSettings");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "users",
                table: "ModuleSettings");

            migrationBuilder.RenameColumn(
                name: "Settings",
                schema: "users",
                table: "ModuleSettings",
                newName: "Setting");

            migrationBuilder.CreateTable(
                name: "Properties",
                schema: "users",
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

            migrationBuilder.UpdateData(
                schema: "users",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "BusinessId", "CreatedDate", "HashCode", "HashPassword" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2022, 9, 17, 17, 27, 49, 757, DateTimeKind.Local).AddTicks(4615), "7ffeb14d-a8c9-42f6-8ef9-ac8c31304848", "kQNPrDKgMDJ42+hvlggRrQ==" });
        }
    }
}
