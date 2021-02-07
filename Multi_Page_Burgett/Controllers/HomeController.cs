using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Multi_Page_Burgett.Models;

namespace Multi_Page_Burgett.Controllers
{
    public class HomeController : Controller
    {
        private ContactsContext context { get; set; }

        public HomeController(ContactsContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts
                .Include(m => m.Designation)
                .OrderBy(m => m.Name)
                .ToList();
            return View(contacts.ToList());
        }
    }
}
