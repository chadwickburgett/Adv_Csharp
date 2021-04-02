using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketingSystemBurgett.Models;

namespace ticketingSystemBurgett.Controllers
{
    public class HomeController : Controller
    {
        /*
            private Repository<Ticketing> ticketings { get; set; }
            private Repository<Status> statuses { get; set; }
            private Repository<Category> categories { get; set; }
        */
        private readonly TicketingContext context;

        public HomeController(TicketingContext ctx)

        {
            /*
            ticketings = new Repository<Ticketing>(ctx);
            statuses = new Repository<Status>(ctx);
            categories = new Repository<Category>(ctx);
            */
            context = ctx;
        }

        public ViewResult Index()
        {
            /*
            var ticketOptions = new QueryOptions<Ticketing>
            {
              OrderBy = d => d.Id
            };

            var statusOptions = new QueryOptions<Status>
            {
            };

            var categoryOptions = new QueryOptions<Category>
            {
              OrderBy = d => d.CategoryId
            };

            if (id == 0) {
              statusOptions.OrderBy = c => c.StatusId;
            } else {
              statusOptions.Where = c => c.StatusId == id;
              statusOptions.OrderBy = c => c.StatusId;
            }
            */

            // execute queries
            ViewBag.Ticketing = context.Ticketing.Include(s => s.Status).Include(c => c.Category).ToList();
            return View(ViewBag.Ticketing);
        }
    }
}
