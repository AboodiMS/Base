using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    public partial class InitialUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "users");

            migrationBuilder.CreateTable(
                name: "ActionLogger",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Table = table.Column<string>(type: "text", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: true),
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectData = table.Column<object>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLogger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomPowers",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Powers = table.Column<string[]>(type: "jsonb", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleSettings",
                schema: "users",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Settings = table.Column<object>(type: "jsonb", nullable: true),
                    xmin = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleSettings", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TreePowers",
                schema: "users",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Num = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsEndPoint = table.Column<bool>(type: "boolean", nullable: false),
                    DependsOn = table.Column<string[]>(type: "jsonb", nullable: true),
                    ParentCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreePowers", x => x.Code);
                    table.ForeignKey(
                        name: "FK_TreePowers_TreePowers_ParentCode",
                        column: x => x.ParentCode,
                        principalSchema: "users",
                        principalTable: "TreePowers",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    HashPassword = table.Column<string>(type: "text", nullable: false),
                    HashCode = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    VerifyEmailCode = table.Column<string>(type: "text", nullable: false),
                    VerifyEmailDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PhonNum = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Powers = table.Column<string[]>(type: "jsonb", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    SignOutExpirationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastUpdateDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LastUpdateUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "users",
                table: "ModuleSettings",
                columns: new[] { "Code", "Name" },
                values: new object[] { "users-modules", "Users Managament"});

            migrationBuilder.InsertData(
                schema: "users",
                table: "TreePowers",
                columns: new[] { "Code", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCode" },
                values: new object[] { "users-module", null, false, "قسم المستخدمين", 1, null });

            migrationBuilder.InsertData(
                schema: "users",
                table: "Users",
                columns: new[] { "Id", "BusinessId", "CreatedDate", "CreatedUserId", "Email", "HashCode", "HashPassword", "IsActive", "IsAdmin", "IsDeleted", "LastUpdateDate", "LastUpdateUserId", "LoginName", "Name", "Note", "PhonNum", "Powers", "SignOutExpirationDate", "VerifyEmailCode", "VerifyEmailDate" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTimeOffset(new DateTime(2023, 1, 21, 7, 24, 57, 784, DateTimeKind.Unspecified).AddTicks(9854), new TimeSpan(0, 3, 0, 0, 0)), new Guid("11111111-1111-1111-1111-111111111111"), null, "1d763488-1865-425b-8229-e8d4dbf8f689", "wO9wXh8bhJd4PAf+H/x6DA==", true, true, false, null, null, "1", "admin", "", "", null, null, "", null });

            migrationBuilder.InsertData(
                schema: "users",
                table: "TreePowers",
                columns: new[] { "Code", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCode" },
                values: new object[] { "users-module/Users", null, false, "معلومات المستخدمين", 101, "users-module" });

            migrationBuilder.InsertData(
                schema: "users",
                table: "TreePowers",
                columns: new[] { "Code", "DependsOn", "IsEndPoint", "Name", "Num", "ParentCode" },
                values: new object[,]
                {
                    { "users-module/Users/ChangePowers", new[] { "users-module/Users/GetById", "users-module/Users/GetAll" }, true, "تعديل الصلاحيات", 10106, "users-module/Users" },
                    { "users-module/Users/Create", null, true, "اضافة", 10103, "users-module/Users" },
                    { "users-module/Users/Delete", new[] { "users-module/Users/GetById", "users-module/Users/GetAll" }, true, "حذف", 10105, "users-module/Users" },
                    { "users-module/Users/GetAll", null, true, "عرض الكل", 10101, "users-module/Users" },
                    { "users-module/Users/GetById", null, true, "عرض", 10102, "users-module/Users" },
                    { "users-module/Users/Update", new[] { "users-module/Users/GetById", "users-module/Users/GetAll" }, true, "تعديل", 10104, "users-module/Users" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomPower_Name",
                schema: "users",
                table: "CustomPowers",
                columns: new[] { "Name", "BusinessId" },
                unique: true,
                filter: "\"IsDeleted\" = false");

            migrationBuilder.CreateIndex(
                name: "IX_TreePowers_ParentCode",
                schema: "users",
                table: "TreePowers",
                column: "ParentCode");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                schema: "users",
                table: "Users",
                columns: new[] { "Email", "BusinessId" },
                unique: true,
                filter: "\"IsDeleted\" = false");

            migrationBuilder.CreateIndex(
                name: "IX_User_Name",
                schema: "users",
                table: "Users",
                columns: new[] { "Name", "BusinessId" },
                unique: true,
                filter: "\"IsDeleted\" = false");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                schema: "users",
                table: "Users",
                columns: new[] { "LoginName", "BusinessId" },
                unique: true,
                filter: "\"IsDeleted\" = false");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLogger",
                schema: "users");

            migrationBuilder.DropTable(
                name: "CustomPowers",
                schema: "users");

            migrationBuilder.DropTable(
                name: "ModuleSettings",
                schema: "users");

            migrationBuilder.DropTable(
                name: "TreePowers",
                schema: "users");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "users");
        }
    }
}
