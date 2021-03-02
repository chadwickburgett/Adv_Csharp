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

        public IActionResult Index(string activeGame = "all",
                                    string activeCat = "all",
                                    string activeSport = "all")
        {
            var data = new CountryListViewModel
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
                    t => t.Game.GameID.ToLower() == activeGame.ToLower());
            if (activeCat != "all")
                query = query.Where(
                    t => t.Category.CategoryId.ToLower() == activeCat.ToLower());
            if (activeSport != "all")
                query = query.Where(
                    t => t.Sport.SportID.ToLower() == activeSport.ToLower());
            data.Countries = query.ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult Details(CountryViewModel model)
        {
            TempData["ActiveGame"] = model.ActiveGame;
            TempData["ActiveCat"] = model.ActiveCat;
            TempData["ActiveSport"] = model.ActiveSport;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(t => t.Game)
                    .Include(t => t.Sport)
                    .Include(t => t.Category)
                    .FirstOrDefault(t => t.CountryID == id),
                ActiveGame = TempData?["ActiveGame"]?.ToString() ?? "all",
                ActiveCat = TempData?["ActiveCat"]?.ToString() ?? "all",
                ActiveSport = TempData?["ActiveSport"]?.ToString() ?? "all"
            };
            return View(model);
        }

    }
}
