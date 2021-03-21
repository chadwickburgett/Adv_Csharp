using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace webAppAddValidationBurgett.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [RegularExpression("(?i)^[a-z0-9 ]+$",
            ErrorMessage = "Name may not contain special characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [Remote("CheckEmail", "Validation")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter an age.")]
        [Range(1, 150, ErrorMessage = "Age must be between 1-150")]
        public int Age { get; set; }
    }
}