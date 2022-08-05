﻿// <auto-generated />
using System;
using Base.Modules.Users.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Base.Modules.Users.DAL.Database.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    partial class UsersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("users")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Base.Modules.Users.Domain.Entities.TreePower", b =>
                {
                    b.Property<string>("CodeName")
                        .HasColumnType("text");

                    b.Property<string[]>("DependsOn")
                        .HasColumnType("text[]");

                    b.Property<bool>("IsEndPoint")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Num")
                        .HasColumnType("integer");

                    b.Property<string>("ParentCodeName")
                        .HasColumnType("text");

                    b.HasKey("CodeName");

                    b.HasIndex("ParentCodeName");

                    b.ToTable("TreePowers", "users");

                    b.HasData(
                        new
                        {
                            CodeName = "mainroot",
                            IsEndPoint = false,
                            Name = "mainroot",
                            Num = 0
                        },
                        new
                        {
                            CodeName = "companies-module",
                            IsEndPoint = false,
                            Name = "قسم الشركة",
                            Num = 1,
                            ParentCodeName = "mainroot"
                        },
                        new
                        {
                            CodeName = "companies-module/Companies",
                            IsEndPoint = false,
                            Name = "معلومات الشركة",
                            Num = 101,
                            ParentCodeName = "companies-module"
                        },
                        new
                        {
                            CodeName = "companies-module/Companies/GetById",
                            IsEndPoint = true,
                            Name = "عرض",
                            Num = 10101,
                            ParentCodeName = "companies-module/Companies"
                        },
                        new
                        {
                            CodeName = "companies-module/Companies/Update",
                            DependsOn = new[] { "companies-module/Companies/GetById" },
                            IsEndPoint = true,
                            Name = "تعديل",
                            Num = 10102,
                            ParentCodeName = "companies-module/Companies"
                        },
                        new
                        {
                            CodeName = "companies-module/Companies/UpdateActiveSections",
                            DependsOn = new[] { "companies-module/Companies/GetById" },
                            IsEndPoint = true,
                            Name = "تعديل",
                            Num = 10103,
                            ParentCodeName = "companies-module/Companies"
                        },
                        new
                        {
                            CodeName = "users-module",
                            IsEndPoint = false,
                            Name = "قسم المستخدمين",
                            Num = 2,
                            ParentCodeName = "mainroot"
                        },
                        new
                        {
                            CodeName = "users-module/Users",
                            IsEndPoint = false,
                            Name = "معلومات المستخدمين",
                            Num = 201,
                            ParentCodeName = "users-module"
                        },
                        new
                        {
                            CodeName = "users-module/Users/GetAll",
                            IsEndPoint = true,
                            Name = "عرض الكل",
                            Num = 20101,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            CodeName = "users-module/Users/GetById",
                            IsEndPoint = true,
                            Name = "عرض",
                            Num = 20102,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            CodeName = "users-module/Users/Add",
                            IsEndPoint = true,
                            Name = "اضافة",
                            Num = 20103,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            CodeName = "users-module/Users/Update",
                            DependsOn = new[] { "users-module/Users/GetById" },
                            IsEndPoint = true,
                            Name = "تعديل",
                            Num = 20104,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            CodeName = "users-module/Users/Delete",
                            DependsOn = new[] { "users-module/Users/GetById" },
                            IsEndPoint = true,
                            Name = "حذف",
                            Num = 20105,
                            ParentCodeName = "users-module/Users"
                        },
                        new
                        {
                            CodeName = "users-module/Users/ChangePowers",
                            DependsOn = new[] { "users-module/Users/GetById" },
                            IsEndPoint = true,
                            Name = "تعديل الصلاحيات",
                            Num = 20106,
                            ParentCodeName = "users-module/Users"
                        });
                });

            modelBuilder.Entity("Base.Modules.Users.Domain.Entities.TreePower", b =>
                {
                    b.HasOne("Base.Modules.Users.Domain.Entities.TreePower", "Parent")
                        .WithMany("SubTreePowers")
                        .HasForeignKey("ParentCodeName")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Base.Modules.Users.Domain.Entities.TreePower", b =>
                {
                    b.Navigation("SubTreePowers");
                });
#pragma warning restore 612, 618
        }
    }
}