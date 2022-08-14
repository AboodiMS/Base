using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class users2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomPowers",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CodeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Powers = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    HashPassword = table.Column<string>(type: "text", nullable: false),
                    HashCode = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    VerifyEmailCode = table.Column<string>(type: "text", nullable: false),
                    VerifyEmailDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PhonNum = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Powers = table.Column<string[]>(type: "text[]", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastUpdateUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsRowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomPower_Name",
                schema: "users",
                table: "CustomPowers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Name",
                schema: "users",
                table: "Users",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                schema: "users",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomPowers",
                schema: "users");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "users");
        }
    }
}
