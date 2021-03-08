using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dataTranferBurgett.Models;

namespace dataTranferBurgett.Controllers
{
    public class HomeController : Controller
    {
        private CountryContext context;

        public HomeController(CountryContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(string activeGame = "all", string activeCat = "all", string activeSport = "all")
        {
            var session = new OlympicsSession(HttpContext.Session);
            session.SetActiveGame(activeGame);
            session.SetActiveCat(activeCat);
            session.SetActiveSport(activeSport);

            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new OlympicsCookies(HttpContext.Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> mycountries = new List<Country>();
                if (ids.Length > 0)
                    mycountries = context.Countries.Include(c => c.Game)
                        .Include(c => c.Category) .Include(c => c.Sport)
                        .Where(c => ids.Contains(c.CountryID)).ToList();
                session.SetMyCountries(mycountries);
            }

            var model = new CountryListViewModel
            {
                ActiveGame = activeGame,
                ActiveCat = activeCat,
                ActiveSport = activeSport,
                Games = context.Games.ToList(),
                Categories = context.Categories.ToList(),
                Sports = context.Sports.ToList()
            };

            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
                query = query.Where(
                    c => c.Game.GameID.ToLower() == activeGame.ToLower());
            if (activeCat != "all")
                query = query.Where(
                    c => c.Category.CategoryId.ToLower() == activeCat.ToLower());
            if (activeSport != "all")
                query = query.Where(
                    c => c.Sport.SportID.ToLower() == activeSport.ToLower());
            model.Countries = query.ToList();

            return View(model);
        }

        public IActionResult Details(string id)
        {
            var session = new OlympicsSession(HttpContext.Session);
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(c => c.Game)
                    .Include(c => c.Category)
                    .Include(c => c.Sport)
                    .FirstOrDefault(c => c.CountryID == id),
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat(),
                ActiveSport = session.GetActiveSport()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries
                .Include(c => c.Game)
                .Include(c => c.Category)
                .Include(c => c.Sport)
                .Where(c => c.CountryID == model.Country.CountryID)
                .FirstOrDefault();

            var session = new OlympicsSession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(model.Country);
            session.SetMyCountries(countries);

            var cookies = new OlympicsCookies(HttpContext.Response.Cookies);
            cookies.SetMyCountryIds(countries);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Index",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveCat = session.GetActiveCat(),
                    ActiveSport = session.GetActiveSport()
                });
        }
    }
}