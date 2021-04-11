using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ticketingBurgett.Models
{
    public class TicketScheduleContext : DbContext
    {
        public TicketScheduleContext(DbContextOptions<TicketScheduleContext> options)
            : base(options)
        { }

        public DbSet<Day> Days { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DayConfig());
            modelBuilder.ApplyConfiguration(new StatusConfig());
            modelBuilder.ApplyConfiguration(new TicketConfig());
        }

    }
}