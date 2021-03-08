using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dataTranferBurgett.Models;

namespace dataTranferBurgett.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new OlympicsSession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat(),
                ActiveSport = session.GetActiveSport(),
                Countries = session.GetMyCountries(),
                UserName = session.GetName()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Change(CountryListViewModel model)
        {
            var session = new OlympicsSession(HttpContext.Session);
            session.SetName(model.UserName);
            return RedirectToAction("Index", "Home", new
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCat = session.GetActiveCat(),
                ActiveSport = session.GetActiveSport()
            });
        }
    }
}