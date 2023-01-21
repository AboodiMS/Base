﻿// <auto-generated />
using System;
using Base.Modules.Companies.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    [DbContext(typeof(CompaniesDbContext))]
    partial class CompaniesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("companies")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Base.Modules.Companies.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string[]>("ActiveSections")
                        .HasColumnType("jsonb");

                    b.Property<string>("CompanyWork")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ExpiryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("FirstActiveDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTimeOffset?>("LastActiveDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("LastUpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastUpdateUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "IX_Company_Name")
                        .IsUnique()
                        .HasFilter("\"IsDeleted\" = false ");

                    b.ToTable("Companies", "companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            ActiveSections = new[] { "Accounting" },
                            CompanyWork = "",
                            CreatedDate = new DateTimeOffset(new DateTime(2023, 1, 21, 7, 21, 50, 501, DateTimeKind.Unspecified).AddTicks(4642), new TimeSpan(0, 3, 0, 0, 0)),
                            CreatedUserId = new Guid("11111111-1111-1111-1111-111111111111"),
                            IsDeleted = false,
                            Name = "اسم الشركة",
                            xmin = 0u
                        });
                });

            modelBuilder.Entity("Base.Modules.Companies.Domain.Entities.Section", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Code");

                    b.HasIndex(new[] { "Name" }, "IX_Section_Name")
                        .IsUnique();

                    b.ToTable("Sections", "companies");
                });

            modelBuilder.Entity("Base.Shared.Entities.ActionLogger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Action")
                        .HasColumnType("text");

                    b.Property<Guid>("BusinessId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<object>("ObjectData")
                        .HasColumnType("jsonb");

                    b.Property<Guid>("ObjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Table")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("ActionLogger", "companies");
                });

            modelBuilder.Entity("Base.Shared.Entities.ModuleSetting", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<object>("Settings")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<long>("xmin")
                        .HasColumnType("bigint");

                    b.HasKey("Code");

                    b.ToTable("ModuleSettings", "companies");

                    b.HasData(
                        new
                        {
                            Code = "companies-modules",
                            Name = "Companies Managament",
                            xmin = 0L
                        });
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

                    b.HasKey("Code");

                    b.HasIndex("ParentCode");

                    b.ToTable("TreePowers", "companies");

                    b.HasData(
                        new
                        {
                            Code = "companies-module",
                            IsEndPoint = false,
                            Name = "قسم الشركة",
                            Num = 1
                        },
                        new
                        {
                            Code = "companies-module/Companies",
                            IsEndPoint = false,
                            Name = "معلومات الشركة",
                            Num = 101,
                            ParentCode = "companies-module"
                        },
                        new
                        {
                            Code = "companies-module/Companies/Update",
                            IsEndPoint = true,
                            Name = "تعديل",
                            Num = 10102,
                            ParentCode = "companies-module/Companies"
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
