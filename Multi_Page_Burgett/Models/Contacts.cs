using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Multi_Page_Burgett.Models
{
    public class Contacts
    {
        public int ContactsId { get; set; }

        [Required(ErrorMessage ="Please enter a Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Phone Number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter an Address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a Note.")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Please enter a Designation.")]
        public string DesignationId { get; set; }
        public Designation Designation { get; set; }
    }
}
