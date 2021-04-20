using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace cremeCoffeeBurgett.Models
{
    public class Country
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "Please enter a Country id.")]
        [Remote("CheckCountry", "Validation", "Area")]
        public string CountryId { get; set; }
        
        [StringLength(25)]
        [Required(ErrorMessage = "Please enter a Country name.")]
        public string Name { get; set; }

        public ICollection<Bean> Beans { get; set; }
    }
}