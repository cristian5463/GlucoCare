﻿// <auto-generated />
using System;
using GlucoCare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GlucoCare.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240615133851_second insuluin")]
    partial class secondinsuluin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GlucoCare.Domain.Entities.ConfigEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("ApplyInsulinSnack")
                        .HasColumnType("boolean");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<bool>("UseCarbsCalc")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("GlucoCare.Domain.Entities.GlucoseReadingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CalorieAmount")
                        .HasColumnType("integer");

                    b.Property<int>("CarbohydrateAmount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdTypeInsulin")
                        .HasColumnType("integer");

                    b.Property<int?>("IdTypeInsulinSecond")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<int>("InsulinDose")
                        .HasColumnType("integer");

                    b.Property<int?>("InsulinDoseSecond")
                        .HasColumnType("integer");

                    b.Property<string>("MealType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProteinAmount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReadingDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ValueGlucose")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("GlucoseReading");
                });

            modelBuilder.Entity("GlucoCare.Domain.Entities.InsulinDoseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Correction")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdTypeInsulin")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("InsulinDose");
                });

            modelBuilder.Entity("GlucoCare.source.Domain.Entities.InsulinEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<bool>("IndividualApplication")
                        .HasColumnType("boolean");

                    b.Property<string>("NameInsulin")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("TypesInsulin")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Insulin");
                });
#pragma warning restore 612, 618
        }
    }
}
