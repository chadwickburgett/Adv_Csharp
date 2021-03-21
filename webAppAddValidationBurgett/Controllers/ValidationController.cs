using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAppAddValidationBurgett.Models;

namespace webAppAddValidationBurgett.Controllers
{
    public class ValidationController : Controller
    {
        private CustomerContext context;
        public ValidationController(CustomerContext ctx) => context = ctx;

        public JsonResult CheckEmail(string emailAddress)
        {
            string msg = Check.EmailExists(context, emailAddress);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}
