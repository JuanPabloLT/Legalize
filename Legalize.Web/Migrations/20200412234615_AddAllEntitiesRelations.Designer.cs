﻿// <auto-generated />
using System;
using Legalize.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Legalize.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200412234615_AddAllEntitiesRelations")]
    partial class AddAllEntitiesRelations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Legalize.Web.Data.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Legalize.Web.Data.Entities.CountryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Legalize.Web.Data.Entities.ExpenseTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ExpenseTypes");
                });

            modelBuilder.Entity("Legalize.Web.Data.Entities.LegalizeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeId");

                    b.HasKey("Id");

                    b.ToTable("Legalizes");
                });

            modelBuilder.Entity("Legalize.Web.Data.Entities.TripDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int?>("ExpenseTypeId");

                    b.Property<string>("PicturePath");

                    b.Property<int?>("Tripid");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseTypeId");

                    b.HasIndex("Tripid");

                    b.ToTable("TripDetails");
                });

            modelBuilder.Entity("Legalize.Web.Data.Entities.TripEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int?>("LegalizeId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TotalAmount");

                    b.Property<int?>("UserId");

                    b.HasKey("id");

                    b.HasIndex("CityId");

                    b.HasIndex("LegalizeId");

                    b.HasIndex("UserId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Legalize.Web.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PicturePath");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Legalize.Web.Data.Entities.CityEntity", b =>
                {
                    b.HasOne("Legalize.Web.Data.Entities.CountryEntity", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Legalize.Web.Data.Entities.TripDetailEntity", b =>
                {
                    b.HasOne("Legalize.Web.Data.Entities.ExpenseTypeEntity", "ExpenseType")
                        .WithMany("TripDetails")
                        .HasForeignKey("ExpenseTypeId");

                    b.HasOne("Legalize.Web.Data.Entities.TripEntity", "Trip")
                        .WithMany("TripDetails")
                        .HasForeignKey("Tripid");
                });

            modelBuilder.Entity("Legalize.Web.Data.Entities.TripEntity", b =>
                {
                    b.HasOne("Legalize.Web.Data.Entities.CityEntity", "City")
                        .WithMany("Trips")
                        .HasForeignKey("CityId");

                    b.HasOne("Legalize.Web.Data.Entities.LegalizeEntity", "Legalize")
                        .WithMany("Trips")
                        .HasForeignKey("LegalizeId");

                    b.HasOne("Legalize.Web.Data.Entities.UserEntity", "User")
                        .WithMany("Trips")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
