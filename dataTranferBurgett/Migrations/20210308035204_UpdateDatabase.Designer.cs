﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dataTranferBurgett.Models;

namespace dataTranferBurgett.Migrations
{
    [DbContext(typeof(CountryContext))]
    [Migration("20210308035204_UpdateDatabase")]
    partial class UpdateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dataTranferBurgett.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = "in",
                            Name = "Indoor"
                        },
                        new
                        {
                            CategoryId = "out",
                            Name = "Outdoor"
                        });
                });

            modelBuilder.Entity("dataTranferBurgett.Models.Country", b =>
                {
                    b.Property<string>("CountryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FlagImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CountryID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GameID");

                    b.HasIndex("SportID");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryID = "Cn",
                            CategoryId = "in",
                            FlagImage = "canada.jfif",
                            GameID = "winter",
                            Name = "Canada",
                            SportID = "Curl"
                        },
                        new
                        {
                            CountryID = "Sw",
                            CategoryId = "in",
                            FlagImage = "sweden.jfif",
                            GameID = "winter",
                            Name = "Sweden",
                            SportID = "Curl"
                        },
                        new
                        {
                            CountryID = "GB",
                            CategoryId = "in",
                            FlagImage = "great_britain.jfif",
                            GameID = "winter",
                            Name = "Great Britain",
                            SportID = "Curl"
                        },
                        new
                        {
                            CountryID = "Jm",
                            CategoryId = "out",
                            FlagImage = "jamaica.jfif",
                            GameID = "winter",
                            Name = "Jamaica",
                            SportID = "Bob"
                        },
                        new
                        {
                            CountryID = "It",
                            CategoryId = "out",
                            FlagImage = "italy.jfif",
                            GameID = "winter",
                            Name = "Italy",
                            SportID = "Bob"
                        },
                        new
                        {
                            CountryID = "Jp",
                            CategoryId = "out",
                            FlagImage = "japan.jfif",
                            GameID = "winter",
                            Name = "Japan",
                            SportID = "Bob"
                        },
                        new
                        {
                            CountryID = "Gm",
                            CategoryId = "in",
                            FlagImage = "germany.jfif",
                            GameID = "summer",
                            Name = "Germany",
                            SportID = "Dive"
                        },
                        new
                        {
                            CountryID = "Ch",
                            CategoryId = "in",
                            FlagImage = "china.jfif",
                            GameID = "summer",
                            Name = "China",
                            SportID = "Dive"
                        },
                        new
                        {
                            CountryID = "Mx",
                            CategoryId = "in",
                            FlagImage = "mexico.jfif",
                            GameID = "summer",
                            Name = "Mexico",
                            SportID = "Dive"
                        },
                        new
                        {
                            CountryID = "Bz",
                            CategoryId = "out",
                            FlagImage = "brazil.jfif",
                            GameID = "summer",
                            Name = "Brazil",
                            SportID = "RC"
                        },
                        new
                        {
                            CountryID = "Nl",
                            CategoryId = "out",
                            FlagImage = "netherlands.jfif",
                            GameID = "summer",
                            Name = "Netherlands",
                            SportID = "RC"
                        },
                        new
                        {
                            CountryID = "US",
                            CategoryId = "out",
                            FlagImage = "USA.jfif",
                            GameID = "summer",
                            Name = "USA",
                            SportID = "RC"
                        },
                        new
                        {
                            CountryID = "Tl",
                            CategoryId = "in",
                            FlagImage = "thailand.jfif",
                            GameID = "para",
                            Name = "Thailand",
                            SportID = "Arch"
                        },
                        new
                        {
                            CountryID = "Ug",
                            CategoryId = "in",
                            FlagImage = "uruguay.jfif",
                            GameID = "para",
                            Name = "Uruguay",
                            SportID = "Arch"
                        },
                        new
                        {
                            CountryID = "Uk",
                            CategoryId = "in",
                            FlagImage = "Ukraine.jfif",
                            GameID = "para",
                            Name = "Ukraine",
                            SportID = "Arch"
                        },
                        new
                        {
                            CountryID = "Au",
                            CategoryId = "out",
                            FlagImage = "Austria.jfif",
                            GameID = "para",
                            Name = "Austria",
                            SportID = "CS"
                        },
                        new
                        {
                            CountryID = "Pk",
                            CategoryId = "out",
                            FlagImage = "Pakistan.jfif",
                            GameID = "para",
                            Name = "Pakistan",
                            SportID = "CS"
                        },
                        new
                        {
                            CountryID = "Zm",
                            CategoryId = "out",
                            FlagImage = "Zimbabwe.jfif",
                            GameID = "para",
                            Name = "Zimbabwe",
                            SportID = "CS"
                        },
                        new
                        {
                            CountryID = "Fc",
                            CategoryId = "in",
                            FlagImage = "France.jfif",
                            GameID = "youth",
                            Name = "France",
                            SportID = "Break"
                        },
                        new
                        {
                            CountryID = "Cy",
                            CategoryId = "in",
                            FlagImage = "Cyprus.jfif",
                            GameID = "youth",
                            Name = "Cyprus",
                            SportID = "Break"
                        },
                        new
                        {
                            CountryID = "Rs",
                            CategoryId = "in",
                            FlagImage = "Russia.jfif",
                            GameID = "youth",
                            Name = "Russia",
                            SportID = "Break"
                        },
                        new
                        {
                            CountryID = "Fl",
                            CategoryId = "out",
                            FlagImage = "Finland.jfif",
                            GameID = "youth",
                            Name = "Finland",
                            SportID = "Skate"
                        },
                        new
                        {
                            CountryID = "Sv",
                            CategoryId = "out",
                            FlagImage = "Slovakia.jfif",
                            GameID = "youth",
                            Name = "Slovakia",
                            SportID = "Skate"
                        },
                        new
                        {
                            CountryID = "Pg",
                            CategoryId = "out",
                            FlagImage = "Portugal.jfif",
                            GameID = "youth",
                            Name = "Portugal",
                            SportID = "Skate"
                        });
                });

            modelBuilder.Entity("dataTranferBurgett.Models.Game", b =>
                {
                    b.Property<string>("GameID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameID");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            GameID = "winter",
                            Name = "Winter Olympics"
                        },
                        new
                        {
                            GameID = "summer",
                            Name = "Summer Olympics"
                        },
                        new
                        {
                            GameID = "para",
                            Name = "Paralympics"
                        },
                        new
                        {
                            GameID = "youth",
                            Name = "Youth Olympic Games"
                        });
                });

            modelBuilder.Entity("dataTranferBurgett.Models.Sport", b =>
                {
                    b.Property<string>("SportID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SportID");

                    b.ToTable("Sport");

                    b.HasData(
                        new
                        {
                            SportID = "Curl",
                            Name = "Curling"
                        },
                        new
                        {
                            SportID = "Bob",
                            Name = "Bobsleigh"
                        },
                        new
                        {
                            SportID = "Dive",
                            Name = "Diving"
                        },
                        new
                        {
                            SportID = "RC",
                            Name = "Road Cycling"
                        },
                        new
                        {
                            SportID = "Arch",
                            Name = "Archery"
                        },
                        new
                        {
                            SportID = "CS",
                            Name = "Canoe Sprint"
                        },
                        new
                        {
                            SportID = "Break",
                            Name = "Breakdancing"
                        },
                        new
                        {
                            SportID = "Skate",
                            Name = "Skateboarding"
                        });
                });

            modelBuilder.Entity("dataTranferBurgett.Models.Country", b =>
                {
                    b.HasOne("dataTranferBurgett.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("dataTranferBurgett.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID");

                    b.HasOne("dataTranferBurgett.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportID");

                    b.Navigation("Category");

                    b.Navigation("Game");

                    b.Navigation("Sport");
                });
#pragma warning restore 612, 618
        }
    }
}
