using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticketingBurgett.Models
{
    public class TicketScheduleUnitOfWork : ITicketScheduleUnitOfWork
    {
        private TicketScheduleContext context { get; set; }
        public TicketScheduleUnitOfWork(TicketScheduleContext ctx) => context = ctx;

        private IRepository<Day> dayData;
        public IRepository<Day> Days
        {
            get
            {
                if (dayData == null)
                    dayData = new Repository<Day>(context);
                return dayData;
            }
        }

        private IRepository<Status> statusData;
        public IRepository<Status> Statuses
        {
            get
            {
                if (statusData == null)
                    statusData = new Repository<Status>(context);
                return statusData;
            }
        }

        private IRepository<Ticket> ticketData;
        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketData == null)
                    ticketData = new Repository<Ticket>(context);
                return ticketData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
