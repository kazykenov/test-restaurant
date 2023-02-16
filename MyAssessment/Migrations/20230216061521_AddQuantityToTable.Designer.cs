﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAssessment.Data;

#nullable disable

namespace MyAssessment.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230216061521_AddQuantityToTable")]
    partial class AddQuantityToTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyAssessment.Model.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("ClosingHour")
                        .HasColumnType("smallint");

                    b.Property<short>("OpeningHour")
                        .HasColumnType("smallint");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("MyAssessment.Model.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hour")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("MyAssessment.Model.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("MyAssessment.Model.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("AllowNumFrom")
                        .HasColumnType("int");

                    b.Property<int>("AllowNumTo")
                        .HasColumnType("int");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("LocationId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("MyAssessment.Model.Location", b =>
                {
                    b.HasOne("MyAssessment.Model.Restaurant", "Restaurant")
                        .WithMany("Locations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("MyAssessment.Model.Reservation", b =>
                {
                    b.HasOne("MyAssessment.Model.Table", "Table")
                        .WithMany("reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("MyAssessment.Model.Table", b =>
                {
                    b.HasOne("MyAssessment.Model.Location", "Location")
                        .WithMany("Tables")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("MyAssessment.Model.Location", b =>
                {
                    b.Navigation("Tables");
                });

            modelBuilder.Entity("MyAssessment.Model.Restaurant", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("MyAssessment.Model.Table", b =>
                {
                    b.Navigation("reservations");
                });
#pragma warning restore 612, 618
        }
    }
}