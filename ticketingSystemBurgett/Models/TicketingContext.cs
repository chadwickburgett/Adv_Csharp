using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ticketingSystemBurgett.Models
{
    public class TicketingContext : DbContext
    {
        public TicketingContext(DbContextOptions<TicketingContext> options)
            : base(options) { }

        public DbSet<Ticketing> Ticketing { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "todo", Name = "To Do" },
                new Status { StatusId = "inprogress", Name = "In Progress" },
                new Status { StatusId = "qa", Name = "Quality Assurance" },
                new Status { StatusId = "done", Name = "Done" }
            );
        }
    }
}
