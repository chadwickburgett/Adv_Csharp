using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cremeCoffeeBurgett.Models
{
    public partial class Bean
    {
        public int BeanId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(200)]
        public string Name { get; set; }

        [Range(0.0, 1000000.0, ErrorMessage = "Price must be more than 0.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please select a Country.")]
        public string CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<CoffeeOrigin> CoffeeOrigins { get; set; }
    }
}
