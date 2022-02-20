﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shipwithme.Models;

namespace shipwithme.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20220127234102_dsjd")]
    partial class dsjd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ChatApp.Models.Users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("shipwithme.Models.Adminlogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Gmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("systemroll")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adminlogin");
                });

            modelBuilder.Entity("shipwithme.Models.Airportlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Airport")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airportlist");
                });

            modelBuilder.Entity("shipwithme.Models.Citylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Citylist");
                });

            modelBuilder.Entity("shipwithme.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ArivalDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvailableWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsNegotionable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefferedDeliveryDestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefferedDeliveryTimeAfterArival")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefferedPackageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefferedPickupDestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PricePerKG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToAirport")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("shipwithme.Models.Preference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AvailableWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToAirport")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Preference");
                });

            modelBuilder.Entity("shipwithme.Models.PurposalImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PurposalImages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("purposalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PurposalImage");
                });

            modelBuilder.Entity("shipwithme.Models.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExtraPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportStaus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("shipwithme.Models.countrylist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("countrylist");
                });

            modelBuilder.Entity("shipwithme.Models.createpurposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AvailableWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlightDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsNegotionable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MorePackageSubType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageSubType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefferedDeliveryDestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefferedDeliveryTimeAfterArival")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrefferedPickupDestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PricePerKG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequiredWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToAirport")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Createpurposal");
                });
#pragma warning restore 612, 618
        }
    }
}
