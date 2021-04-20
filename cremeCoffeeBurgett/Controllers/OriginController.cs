using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cremeCoffeeBurgett.Models;

namespace cremeCoffeeBurgett.Controllers
{
    public class OriginController : Controller
    {
        private Repository<Origin> data { get; set; }
        public OriginController(CoffeeshopContext ctx) => data = new Repository<Origin>(ctx);

        public IActionResult Index() => RedirectToAction("List");

        public ViewResult List(GridDTO vals)
        {
            string defaultSort = nameof(Origin.Name);
            var builder = new GridBuilder(HttpContext.Session, vals, defaultSort);
            builder.SaveRouteSegments();

            var options = new QueryOptions<Origin>
            {
                Include = "CoffeeOrigins.Bean",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };
            if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
                options.OrderBy = a => a.Name;
            else
                options.OrderBy = a => a.Process;

            var vm = new OriginListViewModel
            {
                Origins = data.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Count)
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var origin = data.Get(new QueryOptions<Origin>
            {
                Include = "CoffeeOrigins.Bean",
                Where = a => a.OriginId == id
            });
            return View(origin);
        }
    }
}