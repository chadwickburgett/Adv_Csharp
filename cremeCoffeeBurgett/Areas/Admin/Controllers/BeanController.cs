using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using cremeCoffeeBurgett.Models;

namespace cremeCoffeeBurgett.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BeanController : Controller
    {
        private CoffeeshopUnitOfWork data { get; set; }
        public BeanController(CoffeeshopContext ctx) => data = new CoffeeshopUnitOfWork(ctx);

        public ViewResult Index() {
            var search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid) {
                var search = new SearchData(TempData) {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }  
            else {
                return RedirectToAction("Index");
            }   
        }

        [HttpGet]
        public ViewResult Search() 
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm) {
                var vm = new SearchViewModel {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Bean> {
                    Include = "Country, CoffeeOrigins.Origin"
                };
                if (search.IsBean) { 
                    options.Where = b => b.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for bean name '{vm.SearchTerm}'";
                }
                if (search.IsOrigin) {
                    int index = vm.SearchTerm.LastIndexOf(' ');
                    if (index == -1) {
                        options.Where = b => b.CoffeeOrigins.Any(
                            ba => ba.Origin.Name.Contains(vm.SearchTerm) || 
                            ba.Origin.Process.Contains(vm.SearchTerm));
                    }
                    else {
                        string name = vm.SearchTerm.Substring(0, index);
                        string process = vm.SearchTerm.Substring(index + 1); 
                        options.Where = b => b.CoffeeOrigins.Any(
                            ba => ba.Origin.Name.Contains(name) && 
                            ba.Origin.Process.Contains(process));
                    }
                    vm.Header = $"Search results for origin '{vm.SearchTerm}'";
                }
                if (search.IsCountry) {                  
                    options.Where = b => b.CountryId.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for country ID '{vm.SearchTerm}'";
                }
                vm.Beans = data.Beans.List(options);
                return View("SearchResults", vm);
            }
            else {
                return View("Index");
            }     
        }

        [HttpGet]
        public ViewResult Add(int id) => GetBean(id, "Add");

        [HttpPost]
        public IActionResult Add(BeanViewModel vm)
        {
            if (ModelState.IsValid) {
                data.LoadNewCoffeeOrigins(vm.Bean, vm.SelectedOrigins);
                data.Beans.Insert(vm.Bean);
                data.Save();

                TempData["message"] = $"{vm.Bean.Name} added to Beans.";
                return RedirectToAction("Index");  
            }
            else {
                Load(vm, "Add");
                return View("Bean", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetBean(id, "Edit");
        
        [HttpPost]
        public IActionResult Edit(BeanViewModel vm)
        {
            if (ModelState.IsValid) {
                data.DeleteCurrentCoffeeOrigins(vm.Bean);
                data.LoadNewCoffeeOrigins(vm.Bean, vm.SelectedOrigins);
                data.Beans.Update(vm.Bean);
                data.Save(); 
                
                TempData["message"] = $"{vm.Bean.Name} updated.";
                return RedirectToAction("Search");  
            }
            else {
                Load(vm, "Edit");
                return View("Bean", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetBean(id, "Delete");

        [HttpPost]
        public IActionResult Delete(BeanViewModel vm)
        {
            data.Beans.Delete(vm.Bean); 
            data.Save();
            TempData["message"] = $"{vm.Bean.Name} removed from Beans.";
            return RedirectToAction("Search");  
        }

        private ViewResult GetBean(int id, string operation)
        {
            var bean = new BeanViewModel();
            Load(bean, operation, id);
            return View("Bean", bean);
        }
        private void Load(BeanViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op)) { 
                vm.Bean = new Bean();
            }
            else {
                vm.Bean = data.Beans.Get(new QueryOptions<Bean>
                {
                    Include = "CoffeeOrigins.Origin, Country",
                    Where = b => b.BeanId == (id ?? vm.Bean.BeanId)
                });
            }

            vm.SelectedOrigins = vm.Bean.CoffeeOrigins?.Select(
                ba => ba.Origin.OriginId).ToArray();
            vm.Origins = data.Origins.List(new QueryOptions<Origin> {
                OrderBy = a => a.Name });
            vm.Countries = data.Countries.List(new QueryOptions<Country> {
                    OrderBy = g => g.Name });
        }

    }
}