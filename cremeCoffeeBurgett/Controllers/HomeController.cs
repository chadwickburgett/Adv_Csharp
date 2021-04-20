using cremeCoffeeBurgett.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace cremeCoffeeBurgett.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Bean> data { get; set; }
        public HomeController(CoffeeshopContext ctx) => data = new Repository<Bean>(ctx);

        public ViewResult Index()
        {
            var random = data.Get(new QueryOptions<Bean>
            {
                OrderBy = b => Guid.NewGuid()
            });

            return View(random);
        }
    }
}