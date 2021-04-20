using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cremeCoffeeBurgett.Models
{
    internal class SeedCountries : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasData(
                new Country { CountryId = "blend", Name = "Blend" },
                new Country { CountryId = "brazil", Name = "Brazil" },
                new Country { CountryId = "burundi", Name = "Burundi" },
                new Country { CountryId = "columbia", Name = "Columbia" },
                new Country { CountryId = "costa rica", Name = "Costa Rica" },
                new Country { CountryId = "ethiopa", Name = "Ethiopa" },
                new Country { CountryId = "guatemala", Name = "Guatemala" },
                new Country { CountryId = "usa", Name = "USA" },
                new Country { CountryId = "honduras", Name = "Honduras" },
                new Country { CountryId = "kenya", Name = "Kenya" },
                new Country { CountryId = "mexico", Name = "Mexico" },
                new Country { CountryId = "papua new guinea", Name = "Papua New Guinea" },
                new Country { CountryId = "peru", Name = "Peru" },
                new Country { CountryId = "rwanda", Name = "Rwanda" },
                new Country { CountryId = "indonesia", Name = "Indonesia" },
                new Country { CountryId = "tanzania", Name = "Tanzania" }
            );
        }
    }

}
