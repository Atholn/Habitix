﻿// <auto-generated />
using System;
using Habitix.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Habitix.Data.Migrations
{
    [DbContext(typeof(BaseContext))]
    [Migration("20201219104231_RemoveUnnecessaryColumn")]
    partial class RemoveUnnecessaryColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Habitix.Data.Models.Habit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("HabitDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HabitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("HabitixUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDateHabit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HabitixUserId");

                    b.ToTable("Habits");
                });

            modelBuilder.Entity("Habitix.Data.Models.HabitDate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("HabitId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HabitId");

                    b.ToTable("HabitsDates");
                });

            modelBuilder.Entity("Habitix.Data.Models.HabitixUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("HabitixUsers");
                });

            modelBuilder.Entity("Habitix.Data.Models.Habit", b =>
                {
                    b.HasOne("Habitix.Data.Models.HabitixUser", "HabitixUser")
                        .WithMany("Habits")
                        .HasForeignKey("HabitixUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HabitixUser");
                });

            modelBuilder.Entity("Habitix.Data.Models.HabitDate", b =>
                {
                    b.HasOne("Habitix.Data.Models.Habit", "Habit")
                        .WithMany("HabitDates")
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("Habitix.Data.Models.Habit", b =>
                {
                    b.Navigation("HabitDates");
                });

            modelBuilder.Entity("Habitix.Data.Models.HabitixUser", b =>
                {
                    b.Navigation("Habits");
                });
#pragma warning restore 612, 618
        }
    }
}
