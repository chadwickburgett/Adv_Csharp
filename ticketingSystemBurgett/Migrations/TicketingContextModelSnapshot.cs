﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ticketingSystemBurgett.Models;

namespace ticketingSystemBurgett.Migrations
{
    [DbContext(typeof(TicketingContext))]
    partial class TicketingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ticketingSystemBurgett.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ticketingSystemBurgett.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Name = "To Do"
                        },
                        new
                        {
                            StatusId = 2,
                            Name = "In Progress"
                        },
                        new
                        {
                            StatusId = 3,
                            Name = "Quality Assurance"
                        },
                        new
                        {
                            StatusId = 4,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("ticketingSystemBurgett.Models.Ticketing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointValue")
                        .HasColumnType("int");

                    b.Property<int>("SprintNumber")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId1");

                    b.HasIndex("StatusId");

                    b.ToTable("Ticketing");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 0,
                            Description = "Convert feet to inches",
                            Name = "feetToInches",
                            PointValue = 5,
                            SprintNumber = 2,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 0,
                            Description = "Convert inches to feet",
                            Name = "inchesToFeet",
                            PointValue = 15,
                            SprintNumber = 6,
                            StatusId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 0,
                            Description = "Convert inches to meters",
                            Name = "inchesToMeters",
                            PointValue = 10,
                            SprintNumber = 4,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("ticketingSystemBurgett.Models.Ticketing", b =>
                {
                    b.HasOne("ticketingSystemBurgett.Models.Category", "Category")
                        .WithMany("Ticketings")
                        .HasForeignKey("CategoryId1")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ticketingSystemBurgett.Models.Status", "Status")
                        .WithMany("Ticketings")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ticketingSystemBurgett.Models.Category", b =>
                {
                    b.Navigation("Ticketings");
                });

            modelBuilder.Entity("ticketingSystemBurgett.Models.Status", b =>
                {
                    b.Navigation("Ticketings");
                });
#pragma warning restore 612, 618
        }
    }
}