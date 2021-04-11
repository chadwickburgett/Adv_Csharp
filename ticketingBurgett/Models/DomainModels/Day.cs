using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ticketingBurgett.Models
{
    public class Day
    {
        public int DayId { get; set; }

        [StringLength(10)]
        [Required()]
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
