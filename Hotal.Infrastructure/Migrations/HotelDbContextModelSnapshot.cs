﻿// <auto-generated />
using System;
using Hotel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Infrastructure.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    partial class HotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.Domain.BookingHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmergencyContactId")
                        .HasColumnType("int");

                    b.Property<int>("HotelCId")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomHotelId")
                        .HasColumnType("int");

                    b.Property<int>("StateBookingId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmergencyContactId");

                    b.HasIndex("HotelCId");

                    b.HasIndex("RoomHotelId");

                    b.HasIndex("StateBookingId");

                    b.ToTable("BookingHotels");
                });

            modelBuilder.Entity("Hotel.Domain.Deparment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Deparments");
                });

            modelBuilder.Entity("Hotel.Domain.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("Hotel.Domain.EmergencyContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Names")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmergencyContacts");
                });

            modelBuilder.Entity("Hotel.Domain.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Hotel.Domain.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BookingHotelId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingHotelId");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("GenderId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Hotel.Domain.HotelC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeparmentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeparmentId");

                    b.HasIndex("TownId");

                    b.ToTable("HotelCs");
                });

            modelBuilder.Entity("Hotel.Domain.LocationRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Foor")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LocationRooms");
                });

            modelBuilder.Entity("Hotel.Domain.RoomHotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<decimal>("BaseCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HotelCId")
                        .HasColumnType("int");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationRoomId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeRoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelCId");

                    b.HasIndex("LocationRoomId");

                    b.HasIndex("TypeRoomId");

                    b.ToTable("RoomHotels");
                });

            modelBuilder.Entity("Hotel.Domain.StateBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StateBookings");
                });

            modelBuilder.Entity("Hotel.Domain.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeparmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeparmentId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Hotel.Domain.TypeRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TypeRooms");
                });

            modelBuilder.Entity("Hotel.Domain.BookingHotel", b =>
                {
                    b.HasOne("Hotel.Domain.EmergencyContact", "EmergencyContact")
                        .WithMany()
                        .HasForeignKey("EmergencyContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.HotelC", "HotelC")
                        .WithMany()
                        .HasForeignKey("HotelCId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.RoomHotel", "RoomHotel")
                        .WithMany()
                        .HasForeignKey("RoomHotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.StateBooking", "StateBooking")
                        .WithMany()
                        .HasForeignKey("StateBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmergencyContact");

                    b.Navigation("HotelC");

                    b.Navigation("RoomHotel");

                    b.Navigation("StateBooking");
                });

            modelBuilder.Entity("Hotel.Domain.Guest", b =>
                {
                    b.HasOne("Hotel.Domain.BookingHotel", null)
                        .WithMany("Guests")
                        .HasForeignKey("BookingHotelId");

                    b.HasOne("Hotel.Domain.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Hotel.Domain.HotelC", b =>
                {
                    b.HasOne("Hotel.Domain.Deparment", "Deparment")
                        .WithMany()
                        .HasForeignKey("DeparmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Deparment");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Hotel.Domain.RoomHotel", b =>
                {
                    b.HasOne("Hotel.Domain.HotelC", "HotelC")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelCId");

                    b.HasOne("Hotel.Domain.LocationRoom", "LocationRoom")
                        .WithMany()
                        .HasForeignKey("LocationRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotel.Domain.TypeRoom", "TypeRoom")
                        .WithMany()
                        .HasForeignKey("TypeRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelC");

                    b.Navigation("LocationRoom");

                    b.Navigation("TypeRoom");
                });

            modelBuilder.Entity("Hotel.Domain.Town", b =>
                {
                    b.HasOne("Hotel.Domain.Deparment", "Deparment")
                        .WithMany()
                        .HasForeignKey("DeparmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deparment");
                });

            modelBuilder.Entity("Hotel.Domain.BookingHotel", b =>
                {
                    b.Navigation("Guests");
                });

            modelBuilder.Entity("Hotel.Domain.HotelC", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
