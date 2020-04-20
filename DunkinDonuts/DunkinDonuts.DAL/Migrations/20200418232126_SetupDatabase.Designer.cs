﻿// <auto-generated />
using DunkinDonuts.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DunkinDonuts.DAL.Migrations
{
    [DbContext(typeof(DunkinDonutsContext))]
    [Migration("20200418232126_SetupDatabase")]
    partial class SetupDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DunkinDonuts.DAL.EntityModels.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "20oz Iced Coffee",
                            Name = "Large Iced Coffee",
                            Price = 2.80m,
                            QuantityAvailable = 4
                        },
                        new
                        {
                            Id = 2,
                            Description = "Muffin with Blueberries",
                            Name = "Blueberry Muffin",
                            Price = 1.29m,
                            QuantityAvailable = 4
                        },
                        new
                        {
                            Id = 3,
                            Description = "Sausage, Egg, and Cheese Breakfast Sandwich on a Croissant",
                            Name = "Breakfast Sandwich",
                            Price = 3.95m,
                            QuantityAvailable = 5
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            Name = "Glazed Stick Donut",
                            Price = 0.99m,
                            QuantityAvailable = 10
                        },
                        new
                        {
                            Id = 5,
                            Description = "Box of 25 Assorted Donuts Holes",
                            Name = "25ct Box of Munchkins",
                            Price = 7.95m,
                            QuantityAvailable = 5
                        });
                });

            modelBuilder.Entity("DunkinDonuts.DAL.EntityModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPurchases")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DunkinDonuts.DAL.EntityModels.UserItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserItems");
                });
#pragma warning restore 612, 618
        }
    }
}
