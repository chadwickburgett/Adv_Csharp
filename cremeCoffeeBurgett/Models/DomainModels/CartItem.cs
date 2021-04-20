using Newtonsoft.Json;

namespace cremeCoffeeBurgett.Models
{
    public class CartItem
    {
        public BeanDTO Bean { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => Bean.Price * Quantity;
    }
}
