using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ticketingBurgett.Models
{
    internal class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity)
        {
            entity.HasOne(c => c.Status)
                .WithMany(t => t.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
               new Ticket { TicketId = 1, Name = "feetToInches", Description = "Convert feet to inches", StatusId = 1, DayId = 1, MilitaryTime = "1500", sprint = 2, pointValue = 5 },
               new Ticket { TicketId = 2, Name = "inchesToFeet", Description = "Convert inches to feet", StatusId = 1, DayId = 3, MilitaryTime = "1600", sprint = 6, pointValue = 15 },
               new Ticket { TicketId = 3, Name = "inchesToMeters", Description = "Convert inches to meters", StatusId = 1, DayId = 5, MilitaryTime = "1200", sprint = 4, pointValue = 10 }
            );
        }
    }

}
