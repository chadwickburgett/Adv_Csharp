using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticketingBurgett.Models
{
    public interface ITicketScheduleUnitOfWork
    {
        public IRepository<Day> Days { get; }
        public IRepository<Status> Statuses { get; }
        public IRepository<Ticket> Tickets { get; }

        public void Save();
    }
}
