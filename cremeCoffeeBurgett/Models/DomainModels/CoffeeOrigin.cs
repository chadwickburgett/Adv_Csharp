namespace cremeCoffeeBurgett.Models
{
    public class CoffeeOrigin
    {
        public int BeanId { get; set; }
        public int OriginId { get; set; }

        public Origin Origin { get; set; }
        public Bean Bean { get; set; }
    }
}
