using System.Linq;
using System.Collections.Generic;

namespace cremeCoffeeBurgett.Models
{
    public static class CartItemListExtensions
    {
        public static List<CartItemDTO> ToDTO(this List<CartItem> list) =>
            list.Select(ci => new CartItemDTO {
                BeanId = ci.Bean.BeanId,
                Quantity = ci.Quantity
            }).ToList();
    }
}
