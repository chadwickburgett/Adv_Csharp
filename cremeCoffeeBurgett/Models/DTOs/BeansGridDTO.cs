using Newtonsoft.Json;

namespace cremeCoffeeBurgett.Models
{
    public class BeansGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Origin { get; set; } = DefaultFilter;
        public string Country { get; set; } = DefaultFilter;
        public string Price { get; set; } = DefaultFilter;
    }
}
