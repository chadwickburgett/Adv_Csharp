using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ticketingSystemBurgett.Models
{
    internal class TicketingConfig : IEntityTypeConfiguration<Ticketing>
    {
        public void Configure(EntityTypeBuilder<Ticketing> entity)
        {
            entity.HasOne(c => c.Category)
                .WithMany(t => t.Ticketings)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Ticketing { Id = 1, Name = "feetToInches", Description = "Convert feet to inches", PointValue = 5, SprintNumber = 2, StatusId = 1 },
                new Ticketing { Id = 2, Name = "inchesToFeet", Description = "Convert inches to feet", PointValue = 15, SprintNumber = 6, StatusId = 1 },
                new Ticketing { Id = 3, Name = "inchesToMeters", Description = "Convert inches to meters", PointValue = 10, SprintNumber = 4, StatusId = 1 }
               );
        }
    }
}
