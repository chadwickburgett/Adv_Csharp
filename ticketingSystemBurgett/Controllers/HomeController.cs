using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ticketingSystemBurgett.Models;

namespace ticketingSystemBurgett.Controllers
{
    public class HomeController : Controller
    {
        private TicketingContext context;
        public HomeController(TicketingContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            TicketingViewModel model = new TicketingViewModel();

            var filters = new Filters(id);

            model.Filters = new Filters(id);
            model.Statuses = context.Statuses.ToList();

            IQueryable<Ticketing> query = context.Ticketing
                .Include(t => t.Status);
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
           
            var tickets = query.OrderBy(t => t.SprintNumber).ToList();

            model.Ticket = tickets;
            return View(model);
        }

        public IActionResult Add()
        {
            TicketingViewModel model = new TicketingViewModel();
            model.Statuses = context.Statuses.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TicketingViewModel model)
        {
            if (ModelState.IsValid)
            {
                context.Ticketing.Add(model.CurrentTicket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                model.Statuses = context.Statuses.ToList();
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] string id, Ticketing selected)
        {
            if (selected.StatusId == null)
            {
                context.Ticketing.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.Ticketing.Find(selected.Id);
                selected.StatusId = newStatusId;
                context.Ticketing.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }
    }
}
