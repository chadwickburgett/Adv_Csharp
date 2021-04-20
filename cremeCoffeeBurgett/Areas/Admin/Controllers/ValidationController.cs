using Microsoft.AspNetCore.Mvc;
using cremeCoffeeBurgett.Models;

namespace cremeCoffeeBurgett.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ValidationController : Controller
    {
        private Repository<Origin> originData { get; set; }
        private Repository<Country> countryData { get; set; }

        public ValidationController(CoffeeshopContext ctx)
        { 
            originData = new Repository<Origin>(ctx);
            countryData = new Repository<Country>(ctx);
        }

        public JsonResult CheckCountry(string countryId)
        {
            var validate = new Validate(TempData);
            validate.CheckCountry(countryId, countryData);
            if (validate.IsValid) {
                validate.MarkCountryChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckOrigin(string Name, string Process, string operation)
        {
            var validate = new Validate(TempData);
            validate.CheckOrigin(Name, Process, operation, originData);
            if (validate.IsValid) {
                validate.MarkOriginChecked();
                return Json(true);
            }
            else {
                return Json(validate.ErrorMessage);
            }
        }
    }
}