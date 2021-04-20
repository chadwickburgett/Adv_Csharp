using Microsoft.AspNetCore.Http;

namespace cremeCoffeeBurgett.Models
{
    public class BeansGridBuilder : GridBuilder
    {
        public BeansGridBuilder(ISession sess) : base(sess) { }

        public BeansGridBuilder(ISession sess, BeansGridDTO values, 
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isInitial = values.Country.IndexOf(FilterPrefix.Country) == -1;
            routes.OriginFilter = (isInitial) ? FilterPrefix.Origin + values.Origin : values.Origin;
            routes.CountryFilter = (isInitial) ? FilterPrefix.Country + values.Country : values.Country;
            routes.PriceFilter = (isInitial) ? FilterPrefix.Price + values.Price : values.Price;
        }

        public void LoadFilterSegments(string[] filter, Origin origin)
        {
            if (origin == null) { 
                routes.OriginFilter = FilterPrefix.Origin + filter[0];
            } else {
                routes.OriginFilter = FilterPrefix.Origin + filter[0]
                    + "-" + origin.Name.Slug();
            }
            routes.CountryFilter = FilterPrefix.Country + filter[1];
            routes.PriceFilter = FilterPrefix.Price + filter[2];
        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = BeansGridDTO.DefaultFilter;   
        public bool IsFilterByOrigin => routes.OriginFilter != def;
        public bool IsFilterByCountry => routes.CountryFilter != def;
        public bool IsFilterByPrice => routes.PriceFilter != def;

        public bool IsSortByCountry =>
            routes.SortField.EqualsNoCase(nameof(Country));
        public bool IsSortByPrice =>
            routes.SortField.EqualsNoCase(nameof(Bean.Price));
    }
}
