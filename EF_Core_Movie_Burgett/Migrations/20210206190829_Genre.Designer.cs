﻿// <auto-generated />
using System;
using EF_Core_Movie_Burgett.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_Core_Movie_Burgett.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20210206190829_Genre")]
    partial class Genre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("EF_Core_Movie_Burgett.Models.Genre", b =>
                {
                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = "A",
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = "C",
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreId = "D",
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = "H",
                            Name = "Horror"
                        },
                        new
                        {
                            GenreId = "M",
                            Name = "Musical"
                        },
                        new
                        {
                            GenreId = "R",
                            Name = "RomCom"
                        },
                        new
                        {
                            GenreId = "S",
                            Name = "SciFi"
                        });
                });

            modelBuilder.Entity("EF_Core_Movie_Burgett.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 4,
                            GenreId = "D",
                            Name = "Casablanca",
                            Rating = 5,
                            Year = 1943
                        },
                        new
                        {
                            MovieId = 2,
                            GenreId = "A",
                            Name = "Wonder Woman",
                            Rating = 3,
                            Year = 2017
                        },
                        new
                        {
                            MovieId = 3,
                            GenreId = "R",
                            Name = "Moonstruck",
                            Rating = 4,
                            Year = 1988
                        });
                });

            modelBuilder.Entity("EF_Core_Movie_Burgett.Models.Movie", b =>
                {
                    b.HasOne("EF_Core_Movie_Burgett.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
