using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace cremeCoffeeBurgett.Models
{
    public class Origin
    {
        public int OriginId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a process name.")]
        [MaxLength(200)]
        [Remote("CheckOrigin", "Validation", "Area", 
            AdditionalFields = "Name, Operation")]
        public string Process { get; set; }

        public string FullName => $"{Name} {Process}";

        public ICollection<CoffeeOrigin> CoffeeOrigins { get; set; }
    }
}
