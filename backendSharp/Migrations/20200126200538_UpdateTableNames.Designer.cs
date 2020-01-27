﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Trowoo;

namespace Trowoo.Migrations
{
    [DbContext(typeof(TrowooDbContext))]
    [Migration("20200126200538_UpdateTableNames")]
    partial class UpdateTableNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Trowoo.Models.HighPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PositionId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("HighPrices");
                });

            modelBuilder.Entity("Trowoo.Models.LowPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PositionId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("LowPrices");
                });

            modelBuilder.Entity("Trowoo.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("Trowoo.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("OpenedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("PortfolioId")
                        .HasColumnType("integer");

                    b.Property<long?>("SecurityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("SecurityId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Trowoo.Models.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("AdjustedClose")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Close")
                        .HasColumnType("numeric");

                    b.Property<decimal>("DividendAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("High")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Low")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Open")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("QuoteDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("SecurityId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SplitCoefficient")
                        .HasColumnType("numeric");

                    b.Property<int>("Volume")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SecurityId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("Trowoo.Models.Security", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Ticker")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("Trowoo.Models.TrailingStop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Percent")
                        .HasColumnType("numeric");

                    b.Property<int?>("PositionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("TrailingStops");
                });

            modelBuilder.Entity("Trowoo.Models.HighPrice", b =>
                {
                    b.HasOne("Trowoo.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("Trowoo.Models.LowPrice", b =>
                {
                    b.HasOne("Trowoo.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("Trowoo.Models.Position", b =>
                {
                    b.HasOne("Trowoo.Models.Portfolio", null)
                        .WithMany("Positions")
                        .HasForeignKey("PortfolioId");

                    b.HasOne("Trowoo.Models.Security", "Security")
                        .WithMany()
                        .HasForeignKey("SecurityId");
                });

            modelBuilder.Entity("Trowoo.Models.Quote", b =>
                {
                    b.HasOne("Trowoo.Models.Security", "Security")
                        .WithMany("Quotes")
                        .HasForeignKey("SecurityId");
                });

            modelBuilder.Entity("Trowoo.Models.TrailingStop", b =>
                {
                    b.HasOne("Trowoo.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
                });
#pragma warning restore 612, 618
        }
    }
}