using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticketingSystemBurgett.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all";
            string[] filters = FilterString.Split('-');
            StatusId = filters[0];
        }
        public string FilterString { get; }

        public string StatusId { get; }

        public bool HasStatus => StatusId.ToLower() != "all";

    }
}

