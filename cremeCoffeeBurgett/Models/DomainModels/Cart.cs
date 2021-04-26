using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace cremeCoffeeBurgett.Models
{
    public class Cart
    {
        private const string CartKey = "mycart";
        private const string CountKey = "mycount";

        private List<CartItem> items { get; set; }
        private List<CartItemDTO> storedItems { get; set; }

        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public Cart(HttpContext ctx)
        {
            session = ctx.Session;
            requestCookies = ctx.Request.Cookies;
            responseCookies = ctx.Response.Cookies;
        }

        public void Load(Repository<Bean> data)
        {
            items = session.GetObject<List<CartItem>>(CartKey);
            if (items == null) {
                items = new List<CartItem>();
                storedItems = requestCookies.GetObject<List<CartItemDTO>>(CartKey);
            }
            if (storedItems?.Count > items?.Count) {
                foreach (CartItemDTO storedItem in storedItems) {
                    var bean = data.Get(new QueryOptions<Bean> {
                        Include = "CoffeeOrigins.Origin, Country",
                        Where = b => b.BeanId == storedItem.BeanId
                    });
                    if (bean != null) {
                        var dto = new BeanDTO();
                        dto.Load(bean);

                        CartItem item = new CartItem {
                            Bean = dto,
                            Quantity = storedItem.Quantity
                        };
                        items.Add(item);
                    }
                }
                Save();
            }
        }

        public double Subtotal => items.Sum(i => i.Subtotal);
        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetInt32(CountKey);
        public IEnumerable<CartItem> List => items;

        public CartItem GetById(int id) => 
            items.FirstOrDefault(ci => ci.Bean.BeanId == id);

        public void Add(CartItem item) {
            var itemInCart = GetById(item.Bean.BeanId);
            
            if (itemInCart == null) {
                items.Add(item);
            }
            else {  
                itemInCart.Quantity += 1;
            }
        }

        public void Edit(CartItem item)
        {
            var itemInCart = GetById(item.Bean.BeanId);
            if (itemInCart != null) {
                itemInCart.Quantity = item.Quantity;
            }
        }

        public void Remove(CartItem item) => items.Remove(item);
        public void Clear() => items.Clear();
        
        public void Save() {
            if (items.Count == 0) {
                session.Remove(CartKey);
                session.Remove(CountKey);
                responseCookies.Delete(CartKey);
                responseCookies.Delete(CountKey);
            }
            else {
                session.SetObject<List<CartItem>>(CartKey, items);
                session.SetInt32(CountKey, items.Count);
                responseCookies.SetObject<List<CartItemDTO>>(CartKey, items.ToDTO());
                responseCookies.SetInt32(CountKey, items.Count);
            }
        }
    }
}
