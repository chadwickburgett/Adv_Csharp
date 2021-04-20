using System.Collections.Generic;

namespace cremeCoffeeBurgett.Models
{
    public class OriginListViewModel
    {
        public IEnumerable<Origin> Origins { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
