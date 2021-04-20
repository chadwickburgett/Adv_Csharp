using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cremeCoffeeBurgett.Models;

namespace cremeCoffeeBurgett.Controllers
{
    public class BeanController : Controller
    {
        private CoffeeshopUnitOfWork data { get; set; }
        public BeanController(CoffeeshopContext ctx) => data = new CoffeeshopUnitOfWork(ctx);

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(BeansGridDTO values)
        {
            var builder = new BeansGridBuilder(HttpContext.Session, values,
                defaultSortField: nameof(Bean.Name));

            var options = new BeanQueryOptions
            {
                Include = "CoffeeOrigins.Origin, Country",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new BeanListViewModel
            {
                Beans = data.Beans.List(options),
                Origins = data.Origins.List(new QueryOptions<Origin>
                {
                    OrderBy = a => a.Name
                }),
                Countries = data.Countries.List(new QueryOptions<Country>
                {
                    OrderBy = g => g.Name
                }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Beans.Count)
            };

            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var bean = data.Beans.Get(new QueryOptions<Bean>
            {
                Include = "CoffeeOrigins.Origin, Country",
                Where = b => b.BeanId == id
            });
            return View(bean);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new BeansGridBuilder(HttpContext.Session);

            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var origin = data.Origins.Get(filter[0].ToInt());
                builder.LoadFilterSegments(filter, origin);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }
}