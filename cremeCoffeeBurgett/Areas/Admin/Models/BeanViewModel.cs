using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cremeCoffeeBurgett.Models
{
    public class BeanViewModel : IValidatableObject
    {
        public Bean Bean { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Origin> Origins { get; set; }
        public int[] SelectedOrigins { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext ctx) {
            if (SelectedOrigins == null)
            {
                yield return new ValidationResult(
                  "Please select at least one origin.",
                  new[] { nameof(SelectedOrigins) });
            }
        }

    }
}
