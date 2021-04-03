﻿// <auto-generated />
using System;
using ContactManager.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactManager.Migrations
{
    [DbContext(typeof(ContactManagerContext))]
    [Migration("20210403184927_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("ContactManager.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Complement")
                        .HasColumnType("TEXT");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "salvador",
                            Complement = "casa 29",
                            Neighborhood = "Castelo Branco",
                            State = "bahia"
                        },
                        new
                        {
                            Id = 2,
                            City = "salvador",
                            Complement = "casa 29",
                            Neighborhood = "Stiep",
                            State = "bahia"
                        },
                        new
                        {
                            Id = 3,
                            City = "salvador",
                            Complement = "casa 29",
                            Neighborhood = "Rio Vermelho",
                            State = "bahia"
                        },
                        new
                        {
                            Id = 4,
                            City = "salvador",
                            Complement = "casa 29",
                            Neighborhood = "Federação",
                            State = "bahia"
                        },
                        new
                        {
                            Id = 5,
                            City = "salvador",
                            Complement = "casa 29",
                            Neighborhood = "Barra",
                            State = "bahia"
                        });
                });

            modelBuilder.Entity("ContactManager.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 2,
                            BirthDate = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lauro@oliveira.com",
                            LastName = "Oliveira",
                            Name = "Lauro"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 3,
                            BirthDate = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Roberto@Soares.com",
                            LastName = "Soares",
                            Name = "Roberto"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 4,
                            BirthDate = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Ronaldo@Marconi.com",
                            LastName = "Marconi",
                            Name = "Ronaldo"
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 5,
                            BirthDate = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Rodrigo@Carvalho.com",
                            LastName = "Carvalho",
                            Name = "Rodrigo"
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 1,
                            BirthDate = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Alexandre@Montanha.com",
                            LastName = "Montanha",
                            Name = "Alexandre"
                        });
                });

            modelBuilder.Entity("ContactManager.Models.Telephone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Telephones");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactId = 2,
                            Number = "123456"
                        },
                        new
                        {
                            Id = 2,
                            ContactId = 3,
                            Number = "654321"
                        },
                        new
                        {
                            Id = 3,
                            ContactId = 1,
                            Number = "124578"
                        },
                        new
                        {
                            Id = 4,
                            ContactId = 5,
                            Number = "134679"
                        },
                        new
                        {
                            Id = 5,
                            ContactId = 4,
                            Number = "875421"
                        },
                        new
                        {
                            Id = 6,
                            ContactId = 2,
                            Number = "976431"
                        },
                        new
                        {
                            Id = 7,
                            ContactId = 1,
                            Number = "258741"
                        },
                        new
                        {
                            Id = 8,
                            ContactId = 1,
                            Number = "147963"
                        });
                });

            modelBuilder.Entity("ContactManager.Models.Contact", b =>
                {
                    b.HasOne("ContactManager.Models.Address", "Address")
                        .WithOne("Contact")
                        .HasForeignKey("ContactManager.Models.Contact", "AddressId");
                });

            modelBuilder.Entity("ContactManager.Models.Telephone", b =>
                {
                    b.HasOne("ContactManager.Models.Contact", "Contact")
                        .WithMany("Telephones")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}