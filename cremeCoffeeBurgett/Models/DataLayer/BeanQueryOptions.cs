using System.Linq;

namespace cremeCoffeeBurgett.Models
{
    public class BeanQueryOptions : QueryOptions<Bean>
    {
        public void SortFilter(BeansGridBuilder builder)
        {
            if (builder.IsFilterByCountry) {
                Where = b => b.CountryId == builder.CurrentRoute.CountryFilter;
            }
            if (builder.IsFilterByPrice) {
                if (builder.CurrentRoute.PriceFilter == "under17")
                    Where = b => b.Price < 17;
                else if (builder.CurrentRoute.PriceFilter == "17to24")
                    Where = b => b.Price >= 17 && b.Price <= 24;
                else
                    Where = b => b.Price > 24;
            }
            if (builder.IsFilterByOrigin) {
                int id = builder.CurrentRoute.OriginFilter.ToInt();
                if (id > 0)
                    Where = b => b.CoffeeOrigins.Any(ba => ba.Origin.OriginId == id);
            }

            if (builder.IsSortByCountry) {
                OrderBy = b => b.Country.Name;
            }
            else if (builder.IsSortByPrice) {
                OrderBy = b => b.Price;
            }
            else  {
                OrderBy = b => b.Name;
            }
        }
    }
}
