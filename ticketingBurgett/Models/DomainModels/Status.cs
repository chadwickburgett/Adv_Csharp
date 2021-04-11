using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ticketingBurgett.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        [Display(Name = "Name")]
        [StringLength(100, ErrorMessage = "Name may not exceed 100 characters.")]
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
