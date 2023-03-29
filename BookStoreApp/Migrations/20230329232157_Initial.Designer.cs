﻿// <auto-generated />
using System;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStoreApp.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    [Migration("20230329232157_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("BookStoreApp.Models.BasketLineItem", b =>
                {
                    b.Property<int>("LineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("LineId");

                    b.HasIndex("BookId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("BasketLineItem");
                });

            modelBuilder.Entity("BookStoreApp.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Classification")
                        .HasColumnType("text");

                    b.Property<string>("Isbn")
                        .HasColumnType("text");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("Publisher")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Victor Hugo",
                            Category = "Classic",
                            Classification = "Fiction",
                            Isbn = "978-0451419439",
                            PageCount = 1488,
                            Price = 9.9499999999999993,
                            Publisher = "Signet",
                            Title = "Les Miserables"
                        },
                        new
                        {
                            BookId = 2,
                            Author = "Doris Kearns Goodwin",
                            Category = "Biography",
                            Classification = "Non-Fiction",
                            Isbn = "978-0743270755",
                            PageCount = 944,
                            Price = 14.58,
                            Publisher = "Simon & Schuster",
                            Title = "Team of Rivals"
                        },
                        new
                        {
                            BookId = 3,
                            Author = "Alice Schroeder",
                            Category = "Biography",
                            Classification = "Non-Fiction",
                            Isbn = "978-0553384611",
                            PageCount = 832,
                            Price = 14.58,
                            Publisher = "Bantam",
                            Title = "The Snowball"
                        },
                        new
                        {
                            BookId = 4,
                            Author = "Ronald C. White",
                            Category = "Biography",
                            Classification = "Non-Fiction",
                            Isbn = "978-0812981254",
                            PageCount = 864,
                            Price = 21.539999999999999,
                            Publisher = "Random House",
                            Title = "American Ulysses"
                        },
                        new
                        {
                            BookId = 5,
                            Author = "Laura Hillenbrand",
                            Category = "Historical",
                            Classification = "Non-Fiction",
                            Isbn = "978-0812974492",
                            PageCount = 528,
                            Price = 13.33,
                            Publisher = "Random House",
                            Title = "Unbroken"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("text");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("PurchaseId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("BookStoreApp.Models.BasketLineItem", b =>
                {
                    b.HasOne("BookStoreApp.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("BookStoreApp.Models.Purchase", null)
                        .WithMany("Lines")
                        .HasForeignKey("PurchaseId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreApp.Models.Purchase", b =>
                {
                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}