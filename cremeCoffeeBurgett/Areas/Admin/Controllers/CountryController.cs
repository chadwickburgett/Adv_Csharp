using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using cremeCoffeeBurgett.Models;

namespace cremeCoffeeBurgett.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CountryController : Controller
    {
        private Repository<Country> data { get; set; }
        public CountryController(CoffeeshopContext ctx) => data = new Repository<Country>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var countries = data.List(new QueryOptions<Country> {
                OrderBy = g => g.Name
            });
            return View(countries);
        }

        [HttpGet]
        public ViewResult Add() => View("Country", new Country());

        [HttpPost]
        public IActionResult Add(Country country)
        {
            var validate = new Validate(TempData);
            if (!validate.IsCountryChecked) {
                validate.CheckCountry(country.CountryId, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(country.CountryId), validate.ErrorMessage);
                }     
            }

            if (ModelState.IsValid) {
                data.Insert(country);
                data.Save();
                validate.ClearCountry();
                TempData["message"] = $"{country.Name} added to Countries.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Country", country);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("Country", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid) {
                data.Update(country);
                data.Save();
                TempData["message"] = $"{country.Name} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Country", country);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id) {
            var country = data.Get(new QueryOptions<Country> {
                Include = "Countries",
                Where = g => g.CountryId == id
            });

            if (country.Beans.Count > 0) {
                TempData["message"] = $"Can't delete country {country.Name} " 
                                    + "because it's associated with these beans.";
                return GoToBeanSearchResults(id);
            }
            else {
                return View("Country", country);
            }
        }

        [HttpPost]
        public IActionResult Delete(Country country)
        {
            data.Delete(country);
            data.Save();
            TempData["message"] = $"{country.Name} removed from Countries.";
            return RedirectToAction("Index");  
        }

        public RedirectToActionResult ViewBeans(string id) => GoToBeanSearchResults(id);

        private RedirectToActionResult GoToBeanSearchResults(string id)
        {
            var search = new SearchData(TempData) {
                SearchTerm = id,
                Type = "country"
            };
            return RedirectToAction("Search", "Bean");
        }

    }
}