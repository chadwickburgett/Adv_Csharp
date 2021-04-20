using System.Collections.Generic;

namespace cremeCoffeeBurgett.Models
{
    public class BeanListViewModel 
    {
        public IEnumerable<Bean> Beans { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<Origin> Origins { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public Dictionary<string, string> Prices =>
            new Dictionary<string, string> {
                { "under17", "Under $17" },
                { "17to24", "$17 to $24" },
                { "over24", "Over $24" }
            };
    }
}
