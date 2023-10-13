﻿// <auto-generated />
using System;
using MarceloAnimeList.Infra._4._1_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarceloAnimeList.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231013140113_CreateAnime")]
    partial class CreateAnime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Media");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MediaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Score")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.UserAnime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Episode")
                        .HasColumnType("int");

                    b.Property<int>("Season")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAnime");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Anime", b =>
                {
                    b.HasBaseType("MarceloAnimeList.Domain.Entity.Media");

                    b.Property<int?>("EpisodeCount")
                        .HasColumnType("int");

                    b.Property<int?>("Season")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserAnimeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserAnimeId");

                    b.ToTable("Anime", (string)null);
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Manga", b =>
                {
                    b.HasBaseType("MarceloAnimeList.Domain.Entity.Media");

                    b.Property<int>("Chapter")
                        .HasColumnType("int");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.ToTable("Manga");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Movie", b =>
                {
                    b.HasBaseType("MarceloAnimeList.Domain.Entity.Media");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Rating", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Entity.Media", "Media")
                        .WithMany("Ratings")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarceloAnimeList.Domain.Entity.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.UserAnime", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Entity.User", "User")
                        .WithMany("UserAnimes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Anime", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Entity.Media", null)
                        .WithOne()
                        .HasForeignKey("MarceloAnimeList.Domain.Entity.Anime", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarceloAnimeList.Domain.Entity.UserAnime", null)
                        .WithMany("Anime")
                        .HasForeignKey("UserAnimeId");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Manga", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Entity.Media", null)
                        .WithOne()
                        .HasForeignKey("MarceloAnimeList.Domain.Entity.Manga", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Movie", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Entity.Media", null)
                        .WithOne()
                        .HasForeignKey("MarceloAnimeList.Domain.Entity.Movie", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.Media", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.User", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("UserAnimes");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Entity.UserAnime", b =>
                {
                    b.Navigation("Anime");
                });
#pragma warning restore 612, 618
        }
    }
}
