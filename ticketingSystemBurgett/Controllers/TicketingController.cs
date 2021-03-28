using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ticketingSystemBurgett.Models;

namespace ticketingSystemBurgett.Controllers
{
    public class TicketingController : Controller
    {
        private Repository<Ticketing> ticketings { get; set; }
        private Repository<Status> statuses { get; set; }

        public TicketingController(TicketingContext ctx)
        {
            ticketings = new Repository<Ticketing>(ctx);
            statuses = new Repository<Status>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

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
            var c = this.GetTicketing(id);
            return View("Add", c);
        }

        [HttpPost]
        public IActionResult Add(Ticketing t)
        {
            if (ModelState.IsValid)
            {
                if (t.Id == 0)
                    ticketings.Insert(t);
                else
                    ticketings.Update(t);
                ticketings.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string operation = (t.Id == 0) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var c = this.GetTicketing(id);
            return View(c);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Ticketing t)
        {
            ticketings.Delete(t);
            ticketings.Save();
            return RedirectToAction("Index", "Home");
        }

        // private helper methods
        private Ticketing GetTicketing(int id)
        {
            var classOptions = new QueryOptions<Ticketing>
            {
                Includes = "Ticketings",
                Where = t => t.Id == id
            };
            var list = ticketings.List(classOptions);

            // return first Class or blank Class if null
            return list.FirstOrDefault();
        }
        private void LoadViewBag(string operation)
        {
            ViewBag.Ticketings = ticketings.List(new QueryOptions<Ticketing>
            {
                OrderBy = t => t.Id
            });
            ViewBag.Statuses = statuses.List(new QueryOptions<Status>
            {
                OrderBy = t => t.Name
            });
            ViewBag.Operation = operation;
        }
    }
}