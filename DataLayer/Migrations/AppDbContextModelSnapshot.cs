﻿// <auto-generated />
using System;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataLayer.Models.Color", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("DataLayer.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("ManufactureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("ProviderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ProviderID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataLayer.Models.Provider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.HasKey("ID");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("DataLayer.Models.Color", b =>
                {
                    b.HasOne("DataLayer.Models.Product", "Product")
                        .WithMany("Colors")
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("DataLayer.Models.Product", b =>
                {
                    b.HasOne("DataLayer.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("DataLayer.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderID");
                });
#pragma warning restore 612, 618
        }
    }
}