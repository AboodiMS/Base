﻿// <auto-generated />
using System;
using Base.Modules.Companies.DAL.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Base.Modules.Companies.DAL.Database.Migrations
{
    [DbContext(typeof(CompaniesDbContext))]
    [Migration("20220816090622_companies")]
    partial class companies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "IX_Company_Name")
                        .IsUnique();

                    b.ToTable("Companies", "companies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            ActiveSections = new[] { "Accounting" },
                            CompanyWork = "",
                            Name = "اسم الشركة"
                        });
                });

            modelBuilder.Entity("Base.Modules.Companies.Domain.Entities.Section", b =>
                {
                    b.Property<string>("CodeName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("CodeName");

                    b.HasIndex(new[] { "Name" }, "IX_Section_Name")
                        .IsUnique();

                    b.ToTable("Sections", "companies");
                });
#pragma warning restore 612, 618
        }
    }
}