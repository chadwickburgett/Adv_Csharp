using System.Collections.Generic;

namespace cremeCoffeeBurgett.Models
{
    public class CartViewModel 
    {
        public IEnumerable<CartItem> List { get; set; }
        public double Subtotal { get; set; }
        public RouteDictionary BeanGridRoute { get; set; }
    }
}
