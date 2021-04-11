using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ticketingBurgett.Models
{
    internal class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.HasData(
                new Status { StatusId = 1, Name = "to do" },
                new Status { StatusId = 2, Name = "in progress" },
                new Status { StatusId = 3, Name = "quality assurance" },
                new Status { StatusId = 4, Name = "done" }
            );
        }
    }
}
