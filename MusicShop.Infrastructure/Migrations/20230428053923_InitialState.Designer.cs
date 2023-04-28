﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicShop.Infrastructure.Database;

#nullable disable

namespace MusicShop.Infrastructure.Migrations
{
    [DbContext(typeof(MusicShopContext))]
    [Migration("20230428053923_InitialState")]
    partial class InitialState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.16");

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Albums.AlbumEntity", b =>
                {
                    b.Property<Guid>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CoverId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GenreCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AlbumId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CoverId");

                    b.HasIndex("GenreCode");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Albums.AuthorEntity", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MusicBandName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Albums.CoverEntity", b =>
                {
                    b.Property<Guid>("CoverGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("CoverGuid");

                    b.ToTable("Cover");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Albums.GenreEntity", b =>
                {
                    b.Property<string>("GenreCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GenreCode");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Albums.SongEntity", b =>
                {
                    b.Property<Guid>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SongName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SongId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Concerts.ConcertEntity", b =>
                {
                    b.Property<Guid>("ConcertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcertDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ConcertEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ConcertStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcertTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ConcertId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Concert");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.PortfolioEntity", b =>
                {
                    b.Property<Guid>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("PortfolioName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("PortfolioId");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolio");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Albums.AlbumEntity", b =>
                {
                    b.HasOne("MusicShop.Infrastructure.Entities.Albums.AuthorEntity", "Author")
                        .WithMany("Albums")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Infrastructure.Entities.Albums.CoverEntity", "Cover")
                        .WithMany()
                        .HasForeignKey("CoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Infrastructure.Entities.Albums.GenreEntity", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicShop.Infrastructure.Entities.PortfolioEntity", "Portfolio")
                        .WithMany("Albums")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Cover");

                    b.Navigation("Genre");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Albums.SongEntity", b =>
                {
                    b.HasOne("MusicShop.Infrastructure.Entities.Albums.AlbumEntity", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Concerts.ConcertEntity", b =>
                {
                    b.HasOne("MusicShop.Infrastructure.Entities.Albums.AuthorEntity", "Author")
                        .WithMany("Concerts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.PortfolioEntity", b =>
                {
                    b.HasOne("MusicShop.Infrastructure.Entities.UserEntity", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Albums.AlbumEntity", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.Albums.AuthorEntity", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Concerts");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.PortfolioEntity", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicShop.Infrastructure.Entities.UserEntity", b =>
                {
                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
