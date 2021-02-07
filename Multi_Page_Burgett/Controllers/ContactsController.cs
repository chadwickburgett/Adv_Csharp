using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Multi_Page_Burgett.Models;

namespace Multi_Page_Burgett.Controllers
{
    public class ContactsController : Controller
    {
        private ContactsContext context { get; set; }

        public ContactsController(ContactsContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Designation = context.Designations.OrderBy(g => g.Name).ToList();
            return View("Edit", new Contacts());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Designation = context.Designations.OrderBy(g => g.Name).ToList();
            var contact = context.Contacts.Find(id);
            return View(contact); ;
        }

        [HttpPost]
        public IActionResult Edit(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactsId == 0)
                    context.Contacts.Add(contact);
                else
                    context.Contacts.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (contact.ContactsId == 0) ? "Add" : "Edit";
                ViewBag.Designation = context.Designations.OrderBy(g => g.Name).ToList();
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contacts = context.Contacts.Find(id);
            return View(contacts);
        }

        [HttpPost]
        public IActionResult Delete(Contacts contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
