﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticketingSystemBurgett.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Ticketing> Ticketings { get; set; }
    }
}
