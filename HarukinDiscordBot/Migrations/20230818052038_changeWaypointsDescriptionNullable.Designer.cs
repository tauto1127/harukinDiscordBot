﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using firstDiscord.Net.Data;

#nullable disable

namespace firstDiscord.Net.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230818052038_changeWaypointsDescriptionNullable")]
    partial class changeWaypointsDescriptionNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("firstDiscord.Net.Model.TeleportChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Channel")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TeleportChannels");
                });

            modelBuilder.Entity("firstDiscord.Net.Model.WayPoint", b =>
                {
                    b.Property<int>("WayPointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WayPointCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("X")
                        .HasColumnType("REAL");

                    b.Property<float>("Y")
                        .HasColumnType("REAL");

                    b.Property<float>("Z")
                        .HasColumnType("REAL");

                    b.HasKey("WayPointId");

                    b.ToTable("WayPoints");
                });

            modelBuilder.Entity("firstDiscord.Net.Model.WayPointCategory", b =>
                {
                    b.Property<int>("WayPointCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WayPointCategoryId");

                    b.ToTable("WayPointCategories");
                });

            modelBuilder.Entity("firstDiscord.Net.Model.WebBookmark", b =>
                {
                    b.Property<int>("WebBookmarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WebCategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("WebBookmarkId");

                    b.ToTable("WebBookmarks");
                });

            modelBuilder.Entity("firstDiscord.Net.Model.WebCategory", b =>
                {
                    b.Property<int>("WebCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WebCategoryId");

                    b.ToTable("WebCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
