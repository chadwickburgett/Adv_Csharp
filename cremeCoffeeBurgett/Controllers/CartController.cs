using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using cremeCoffeeBurgett.Models;

namespace cremeCoffeeBurgett.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private Repository<Bean> data { get; set; }
        public CartController(CoffeeshopContext ctx) => data = new Repository<Bean>(ctx);


        private Cart GetCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(data);
            return cart;
        }

        public ViewResult Index()
        {
            var cart = GetCart();
            var builder = new BeansGridBuilder(HttpContext.Session);

            var vm = new CartViewModel
            {
                List = cart.List,
                Subtotal = cart.Subtotal,
                BeanGridRoute = builder.CurrentRoute
            };
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var bean = data.Get(new QueryOptions<Bean>
            {
                Include = "CoffeeOrigins.Origin, Country",
                Where = b => b.BeanId == id
            });
            if (bean == null)
            {
                TempData["message"] = "Unable to add bean to cart.";
            }
            else
            {
                var dto = new BeanDTO();
                dto.Load(bean);
                CartItem item = new CartItem
                {
                    Bean = dto,
                    Quantity = 1
                };

                Cart cart = GetCart();
                cart.Add(item);
                cart.Save();

                TempData["message"] = $"{bean.Name} added to cart";
            }

            var builder = new BeansGridBuilder(HttpContext.Session);
            return RedirectToAction("List", "Bean", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetById(id);
            cart.Remove(item);
            cart.Save();

            TempData["message"] = $"{item.Bean.Name} removed from cart.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Cart cart = GetCart();
            cart.Clear();
            cart.Save();

            TempData["message"] = "Cart cleared.";
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            Cart cart = GetCart();
            CartItem item = cart.GetById(id);
            if (item == null)
            {
                TempData["message"] = "Unable to locate cart item";
                return RedirectToAction("List");
            }
            else
            {
                return View(item);
            }
        }

        [HttpPost]
        public RedirectToActionResult Edit(CartItem item)
        {
            Cart cart = GetCart();
            cart.Edit(item);
            cart.Save();

            TempData["message"] = $"{item.Bean.Name} updated";
            return RedirectToAction("Index");
        }

        public ViewResult Checkout() => View();
    }
}