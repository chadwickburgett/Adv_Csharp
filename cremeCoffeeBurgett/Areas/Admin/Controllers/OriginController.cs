using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using cremeCoffeeBurgett.Models;

namespace cremeCoffeeBurgett.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class OriginController : Controller
    {
        private Repository<Origin> data { get; set; }
        public OriginController(CoffeeshopContext ctx) => data = new Repository<Origin>(ctx);

        public ViewResult Index()
        {
            var origins = data.List(new QueryOptions<Origin> {
                OrderBy = a => a.Name
            });
            return View(origins);
        }

        public RedirectToActionResult Select(int id, string operation)
        {
            switch (operation.ToLower())
            {
                case "view beans":
                    return RedirectToAction("ViewBeans", new { id });
                case "edit":
                    return RedirectToAction("Edit", new { id });
                case "delete":
                    return RedirectToAction("Delete", new { id });
                default:
                    return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Add() => View("Origin", new Origin());

        [HttpPost]
        public IActionResult Add(Origin origin, string operation)
        {
            var validate = new Validate(TempData);
            if (!validate.IsOriginChecked) {
                validate.CheckOrigin(origin.Name, origin.Process, operation, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(origin.Process), validate.ErrorMessage);
                }    
            }
            
            if (ModelState.IsValid) {
                data.Insert(origin);
                data.Save();
                validate.ClearOrigin();
                TempData["message"] = $"{origin.FullName} added to Origins.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Origin", origin);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => View("Origin", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Origin origin)
        {
            if (ModelState.IsValid) {
                data.Update(origin);
                data.Save();
                TempData["message"] = $"{origin.FullName} updated.";
                return RedirectToAction("Index");  
            }
            else {
                return View("Origin", origin);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var origin = data.Get(new QueryOptions<Origin> {
                Include = "CoffeeOrigins",
                Where = a => a.OriginId == id
            });

            if (origin.CoffeeOrigins.Count > 0) {
                TempData["message"] = $"Can't delete origin {origin.FullName} because they are associated with these beans.";
                return GoToOriginSearch(origin);
            }
            else {
                return View("Origin", origin);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Origin origin)
        {
            data.Delete(origin);
            data.Save();
            TempData["message"] = $"{origin.FullName} removed from Origins.";
            return RedirectToAction("Index");  
        }

        public RedirectToActionResult ViewBeans(int id)
        {
            var origin = data.Get(id);
            return GoToOriginSearch(origin);
        }

        private RedirectToActionResult GoToOriginSearch(Origin origin)
        {
            var search = new SearchData(TempData) {
                SearchTerm = origin.FullName,
                Type = "origin"
            };
            return RedirectToAction("Search", "Bean");
        }
    }
}