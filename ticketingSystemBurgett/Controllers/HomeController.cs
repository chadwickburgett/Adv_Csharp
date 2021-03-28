using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketingSystemBurgett.Models;

namespace ticketingSystemBurgett.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Ticketing> ticketings { get; set; }
        private Repository<Status> statuses { get; set; }

        public HomeController(TicketingContext ctx)
        {
            ticketings = new Repository<Ticketing>(ctx);
            statuses = new Repository<Status>(ctx);
        }

        public ViewResult Index(int id)
        {
            var ticketOptions = new QueryOptions<Ticketing>
            {
                OrderBy = d => d.Id
            };

            var statusOptions = new QueryOptions<Status>
            {
                Includes = "Ticketings"
            };

            if (id == 0)
            {
                statusOptions.OrderBy = c => c.StatusId;
            }
            else
            {
                statusOptions.Where = c => c.StatusId == id;
                statusOptions.OrderBy = c => c.StatusId;
            }

            // execute queries
            ViewBag.Ticketing = ticketings.List(ticketOptions);
            return View(statuses.List(statusOptions));
        }
    }
}
