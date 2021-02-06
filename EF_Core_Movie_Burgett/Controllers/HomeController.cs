using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EF_Core_Movie_Burgett.Models;

namespace EF_Core_Movie_Burgett.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }

        public HomeController(MovieContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var movies = context.Movies
                .Include(m => m.Genre)
                .OrderBy(m => m.Name)
                .ToList();
            return View(movies);
        }
    }
}