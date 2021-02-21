using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreAppBurgett.Controllers
{
    public class Assignment6_1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]/{id:range(1,10)}")]
        public IActionResult Assignment6_1(int id = 1)
        {
            return View(id);
        }
    }
}
