using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ticketingBurgett.Models;
using Microsoft.AspNetCore.Http;

namespace ticketingBurgett.Controllers
{
    public class HomeController : Controller
    {
        private IHttpContextAccessor http { get; set; }
        private ITicketScheduleUnitOfWork data { get; set; }

        public HomeController(ITicketScheduleUnitOfWork unit, IHttpContextAccessor ctx)
        {
            data = unit;
            http = ctx;
        }

        public ViewResult Index(int id)
        {
            if (id > 0)
            {
                http.HttpContext.Session.SetInt32("dayid", id);
            }

            var dayOptions = new QueryOptions<Day>
            {
                OrderBy = d => d.DayId
            };

            var ticketOptions = new QueryOptions<Ticket>
            {
                Includes = "Status, Day"
            };

            if (id == 0)
            {
                ticketOptions.OrderBy = c => c.DayId;
            }
            else
            {
                ticketOptions.Where = c => c.DayId == id;
                ticketOptions.OrderBy = c => c.MilitaryTime;
            }

            // execute queries
            ViewBag.Days = data.Days.List(dayOptions);
            return View(data.Tickets.List(ticketOptions));
        }
    }
}
