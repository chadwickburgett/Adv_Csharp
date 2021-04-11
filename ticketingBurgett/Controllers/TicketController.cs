using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ticketingBurgett.Models;

namespace ticketingBurgett.Controllers
{
    public class TicketController : Controller
    {
        private IHttpContextAccessor http { get; set; }
        private ITicketScheduleUnitOfWork data { get; set; }

        public TicketController(ITicketScheduleUnitOfWork rep, IHttpContextAccessor ctx)
        {
            data = rep;
            http = ctx;
        }

        public RedirectToActionResult Index()
        {
            http.HttpContext.Session.Remove("dayid");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var t = this.GetTicket(id);
            return View("Add", t);
        }

        [HttpPost]
        public IActionResult Add(Ticket t)
        {
            string operation = (t.TicketId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (t.TicketId == 0)
                    data.Tickets.Insert(t);
                else
                    data.Tickets.Update(t);
                data.Tickets.Save();

                string verb = (operation == "Add") ? "added" : "updated";
                TempData["msg"] = $"{t.Name} {verb}";

                return this.GoToTickets();
            }
            else
            {
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var t = this.GetTicket(id);
            ViewBag.DayId = http.HttpContext.Session.GetInt32("dayid");
            return View(t);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Ticket t)
        {
            t = data.Tickets.Get(t.TicketId);

            data.Tickets.Delete(t);
            data.Tickets.Save();

            TempData["msg"] = $"{t.Name} deleted";

            return this.GoToTickets();
        }

        private Ticket GetTicket(int id)
        {
            var ticketOptions = new QueryOptions<Ticket>
            {
                Includes = "Status, Day",
                Where = t => t.TicketId == id
            };
            return data.Tickets.Get(ticketOptions);
        }

        private void LoadViewBag(string operation)
        {
            ViewBag.Days = data.Days.List(new QueryOptions<Day>
            {
                OrderBy = d => d.DayId
            });
            ViewBag.Status = data.Statuses.List(new QueryOptions<Status>
            {
                OrderBy = t => t.Name
            });

            ViewBag.Operation = operation;
            ViewBag.DayId = http.HttpContext.Session.GetInt32("dayid");
        }

        private RedirectToActionResult GoToTickets()
        {
            if (http.HttpContext.Session.GetInt32("dayid").HasValue)
                return RedirectToAction("Index", "Home", new { id = http.HttpContext.Session.GetInt32("dayid") });
            else
                return RedirectToAction("Index", "Home");
        }
    }
}