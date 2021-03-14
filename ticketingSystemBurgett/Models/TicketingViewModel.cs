using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticketingSystemBurgett.Models
{
    public class TicketingViewModel
    {
        public TicketingViewModel()
        {
            CurrentTicket = new Ticketing();
        }
        public Filters Filters { get; set; }
        public List<Status> Statuses { get; set; }

        public Dictionary<string, string> DueFilters { get; set; }

        public List<Ticketing> Ticket { get; set; }

        public Ticketing CurrentTicket { get; set; }
    }
}
