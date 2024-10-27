﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Terminplaner.Model.Entities;

#nullable disable

namespace Terminplaner.Model.Migrations
{
    [DbContext(typeof(TerminplanerDbContext))]
    partial class TerminplanerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Terminplaner.Model.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Scrum daily",
                            EndTime = new DateTime(2024, 10, 27, 17, 20, 42, 449, DateTimeKind.Local).AddTicks(8711),
                            StartTime = new DateTime(2024, 10, 27, 16, 20, 42, 449, DateTimeKind.Local).AddTicks(8666),
                            Status = "Scheduled",
                            Title = "Meeting",
                            UserId = new Guid("b2b76e15-fb17-4c90-bf60-5016b3c7c6df")
                        },
                        new
                        {
                            Id = 2,
                            Description = "Review code with team",
                            EndTime = new DateTime(2024, 10, 27, 19, 20, 42, 449, DateTimeKind.Local).AddTicks(8720),
                            StartTime = new DateTime(2024, 10, 27, 18, 20, 42, 449, DateTimeKind.Local).AddTicks(8719),
                            Status = "Scheduled",
                            Title = "Code Review",
                            UserId = new Guid("6c7882c9-a14e-4eb8-9377-2b8a7aef4f9c")
                        });
                });

            modelBuilder.Entity("Terminplaner.Model.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b2b76e15-fb17-4c90-bf60-5016b3c7c6df"),
                            Email = "test@test.com",
                            PasswordHash = "test",
                            Role = "Employee",
                            Username = "TestUser"
                        },
                        new
                        {
                            Id = new Guid("6c7882c9-a14e-4eb8-9377-2b8a7aef4f9c"),
                            Email = "admin@admin.com",
                            PasswordHash = "admin",
                            Role = "Administrator",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("Terminplaner.Model.Entities.Appointment", b =>
                {
                    b.HasOne("Terminplaner.Model.Entities.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Terminplaner.Model.Entities.User", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
