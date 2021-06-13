﻿// <auto-generated />
using DropBoxes.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DropBoxes.Migrations
{
    [DbContext(typeof(DropBoxesDbContext))]
    [Migration("20210613151851_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DropBoxes.Database.Models.LootBoxInstance", b =>
                {
                    b.Property<ulong>("SteamId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("LootBoxId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<uint>("Amount")
                        .IsConcurrencyToken()
                        .HasColumnType("int unsigned");

                    b.HasKey("SteamId", "LootBoxId");

                    b.ToTable("DropBoxes_LootBoxes");
                });
#pragma warning restore 612, 618
        }
    }
}
