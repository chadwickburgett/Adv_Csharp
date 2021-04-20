using System.Collections.Generic;

namespace cremeCoffeeBurgett.Models
{
    public class BeanDTO
    {
        public int BeanId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Dictionary<int, string> Origins { get; set; }

        public void Load(Bean bean)
        {
            BeanId = bean.BeanId;
            Name = bean.Name;
            Price = bean.Price;
            Origins = new Dictionary<int, string>();
            foreach (CoffeeOrigin ba in bean.CoffeeOrigins) {
                Origins.Add(ba.Origin.OriginId, ba.Origin.FullName);
            }
        }
    }

}
