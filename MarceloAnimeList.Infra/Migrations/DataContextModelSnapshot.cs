﻿// <auto-generated />
using System;
using MarceloAnimeList.Infra._4._1_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarceloAnimeList.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Media", b =>
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

                    b.ToTable("Media", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Rating", b =>
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

                    b.Property<Guid?>("MediaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Score")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating", (string)null);
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.User", b =>
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

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.UserAnime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid?>("AnimeId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AnimeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAnime", (string)null);
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Anime", b =>
                {
                    b.HasBaseType("MarceloAnimeList.Domain.Data.Entity.Media");

                    b.Property<int?>("EpisodeCount")
                        .HasColumnType("int");

                    b.Property<int?>("Season")
                        .HasColumnType("int");

                    b.ToTable("Anime", (string)null);
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Manga", b =>
                {
                    b.HasBaseType("MarceloAnimeList.Domain.Data.Entity.Media");

                    b.Property<int>("Chapter")
                        .HasColumnType("int");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.ToTable("Manga", (string)null);
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Movie", b =>
                {
                    b.HasBaseType("MarceloAnimeList.Domain.Data.Entity.Media");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.ToTable("Movie", (string)null);
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Rating", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Data.Entity.Media", "Media")
                        .WithMany("Ratings")
                        .HasForeignKey("MediaId");

                    b.HasOne("MarceloAnimeList.Domain.Data.Entity.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId");

                    b.Navigation("Media");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.UserAnime", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Data.Entity.Anime", "Anime")
                        .WithMany()
                        .HasForeignKey("AnimeId");

                    b.HasOne("MarceloAnimeList.Domain.Data.Entity.User", "User")
                        .WithMany("UserAnimes")
                        .HasForeignKey("UserId");

                    b.Navigation("Anime");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Anime", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Data.Entity.Media", null)
                        .WithOne()
                        .HasForeignKey("MarceloAnimeList.Domain.Data.Entity.Anime", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Manga", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Data.Entity.Media", null)
                        .WithOne()
                        .HasForeignKey("MarceloAnimeList.Domain.Data.Entity.Manga", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Movie", b =>
                {
                    b.HasOne("MarceloAnimeList.Domain.Data.Entity.Media", null)
                        .WithOne()
                        .HasForeignKey("MarceloAnimeList.Domain.Data.Entity.Movie", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.Media", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("MarceloAnimeList.Domain.Data.Entity.User", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("UserAnimes");
                });
#pragma warning restore 612, 618
        }
    }
}
