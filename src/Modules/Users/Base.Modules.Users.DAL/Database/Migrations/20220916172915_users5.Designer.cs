﻿// <auto-generated />
using System;
using Base.Modules.Users.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    [Migration("20220916172915_users5")]
    partial class users5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("users")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Base.Modules.Users.Domain.Entities.CustomPower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("IsRowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string[]>("Powers")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name", "BusinessId" }, "IX_CustomPower_Name")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" = false");

                    b.ToTable("CustomPowers", "users");
                });

            modelBuilder.Entity("Base.Modules.Users.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("HashCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("IsRowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.Property<DateTime?>("LastUpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhonNum")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Powers")
                        .HasColumnType("jsonb");

                    b.Property<DateTime?>("SignOutExpirationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("VerifyEmailCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("VerifyEmailDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email", "BusinessId" }, "IX_User_Email")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" = false");

                    b.HasIndex(new[] { "Name", "BusinessId" }, "IX_User_Name")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" = false");

                    b.HasIndex(new[] { "LoginName", "BusinessId" }, "IX_User_UserName")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" = false");

                    b.ToTable("Users", "users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            BusinessId = new Guid("11111111-1111-1111-1111-111111111111"),
                            CreatedDate = new DateTime(2022, 9, 16, 20, 29, 14, 710, DateTimeKind.Local).AddTicks(8101),
                            CreatedUserId = new Guid("11111111-1111-1111-1111-111111111111"),
                            HashCode = "98724994-3abe-480e-9d6f-aafbcc4faed3",
                            HashPassword = "/LfZHXyDgUxU1ZQtHPQE5Q==",
                            IsActive = true,
                            IsAdmin = true,
                            IsDeleted = false,
                            LoginName = "1",
                            Name = "admin",
                            Note = "",
                            PhonNum = "",
                            Powers = new string[0],
                            VerifyEmailCode = ""
                        });
                });

            modelBuilder.Entity("Base.Shared.Entities.ModuleSetting", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<object>("Setting")
                        .HasColumnType("jsonb");

                    b.HasKey("Code");

                    b.ToTable("ModuleSettings", "users");

                    b.HasData(
                        new
                        {
                            Code = "users-modules",
                            Name = "Users Managament"
                        });
                });

            modelBuilder.Entity("Base.Shared.Entities.Properties", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Data")
                        .HasColumnType("jsonb");

                    b.Property<byte[]>("IsRowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("TableName")
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("Properties", "users");
                });

            modelBuilder.Entity("Base.Shared.Entities.TreePower", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string[]>("DependsOn")
                        .HasColumnType("jsonb");

                    b.Property<bool>("IsEndPoint")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Num")
                        .HasColumnType("integer");

                    b.Property<string>("ParentCode")
                        .HasColumnType("text");

                    b.Property<string>("ParentCodeName")
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.HasIndex("ParentCode");

                    b.ToTable("TreePowers", "users");

                    b.HasData(
                        new
                        {
                            Code = "users-module",
                            IsEndPoint = false,
                            Name = "قسم المستخدمين",
                            Num = 1
                        },
                        new
                        {
                            Code = "users-module/Users",
                            IsEndPoint = false,
                            Name = "معلومات المستخدمين",
                            Num = 101,
                            ParentCodeName = "users-module"
                        },
                        new
                        {
                            Code = "users-module/Users/GetAll",
                            IsEndPoint = true,
                            Name = "عرض الكل",
                            Num = 10101,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            Code = "users-module/Users/GetById",
                            IsEndPoint = true,
                            Name = "عرض",
                            Num = 10102,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            Code = "users-module/Users/Add",
                            IsEndPoint = true,
                            Name = "اضافة",
                            Num = 10103,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            Code = "users-module/Users/Update",
                            DependsOn = new[] { "users-module/Users/GetById" },
                            IsEndPoint = true,
                            Name = "تعديل",
                            Num = 10104,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            Code = "users-module/Users/Delete",
                            DependsOn = new[] { "users-module/Users/GetById" },
                            IsEndPoint = true,
                            Name = "حذف",
                            Num = 10105,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            Code = "users-module/Users/ChangePowers",
                            DependsOn = new[] { "users-module/Users/GetById" },
                            IsEndPoint = true,
                            Name = "تعديل الصلاحيات",
                            Num = 10106,
                            ParentCodeName = "users-module/Users"
                        });
                });

            modelBuilder.Entity("Base.Shared.Entities.TreePower", b =>
                {
                    b.HasOne("Base.Shared.Entities.TreePower", "Parent")
                        .WithMany("SubTreePowers")
                        .HasForeignKey("ParentCode");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Base.Shared.Entities.TreePower", b =>
                {
                    b.Navigation("SubTreePowers");
                });
#pragma warning restore 612, 618
        }
    }
}
