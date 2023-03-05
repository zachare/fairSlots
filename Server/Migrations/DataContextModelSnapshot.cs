﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fairSlots.Server.Data;

#nullable disable

namespace fairSlots.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fairSlots.Shared.Chance", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerID"));

                    b.Property<int?>("PlayerID1")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("WinRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PlayerID");

                    b.HasIndex("PlayerID1");

                    b.ToTable("Chances");

                    b.HasData(
                        new
                        {
                            PlayerID = 1,
                            UpdateTime = new DateTime(2023, 3, 3, 18, 34, 17, 830, DateTimeKind.Local).AddTicks(522),
                            WinRate = 0.30m
                        },
                        new
                        {
                            PlayerID = 3,
                            UpdateTime = new DateTime(2023, 3, 3, 18, 34, 17, 830, DateTimeKind.Local).AddTicks(525),
                            WinRate = 0.27m
                        });
                });

            modelBuilder.Entity("fairSlots.Shared.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameID"));

                    b.Property<decimal>("BetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<bool>("Win")
                        .HasColumnType("bit");

                    b.HasKey("GameID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameID = 1,
                            BetAmount = 20.00m,
                            Date = new DateTime(2023, 3, 3, 18, 34, 17, 830, DateTimeKind.Local).AddTicks(329),
                            PlayerID = 1,
                            Win = true
                        },
                        new
                        {
                            GameID = 2,
                            BetAmount = 50.00m,
                            Date = new DateTime(2023, 3, 3, 18, 34, 17, 830, DateTimeKind.Local).AddTicks(484),
                            PlayerID = 2,
                            Win = false
                        });
                });

            modelBuilder.Entity("fairSlots.Shared.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerID"));

                    b.Property<decimal>("Funds")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("PlayerID");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerID = 1,
                            Funds = 200.00m,
                            Username = "Zach"
                        },
                        new
                        {
                            PlayerID = 2,
                            Funds = 5000.00m,
                            Username = "Admin"
                        });
                });

            modelBuilder.Entity("fairSlots.Shared.Chance", b =>
                {
                    b.HasOne("fairSlots.Shared.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID1");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("fairSlots.Shared.Game", b =>
                {
                    b.HasOne("fairSlots.Shared.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
