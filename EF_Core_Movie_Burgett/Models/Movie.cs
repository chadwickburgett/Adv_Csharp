using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EF_Core_Movie_Burgett.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter a Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a Year.")]
        [Range(1889, 2021, ErrorMessage = "Year must be between 1889 - 2021.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Please enter a Rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 - 5.")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Please enter a Genre.")]
        public string GenreId { get; set; }
        public Genre Genre { get; set; }

        public string Slug =>
            Name?.Replace(' ', '-').ToLower() + '-' + Year?.ToString();
    }
}
