using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ticketingBurgett.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [StringLength(200, ErrorMessage = "Name may not exceed 200 characters.")]
        [Required(ErrorMessage = "Please enter a ticket name.")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Description may not exceed 200 characters.")]
        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }


        [Display(Name = "Time")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter numbers only for ticket due time.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Ticket due time must be 4 characters long.")]
        [Required(ErrorMessage = "Please enter a ticket due time (in military time format).")]
        public string MilitaryTime { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int DayId { get; set; }
        public Day Day { get; set; }

        [Range(0, 50, ErrorMessage = "Sprint number must be between 0 and 50.")]
        [Required(ErrorMessage = "Please enter a sprint number.")]
        public int? sprint { get; set; }

        [Range(0, 50, ErrorMessage = "Point value must be between 0 and 50.")]
        [Required(ErrorMessage = "Please enter a point value.")]
        public int? pointValue { get; set; }
    }
}
