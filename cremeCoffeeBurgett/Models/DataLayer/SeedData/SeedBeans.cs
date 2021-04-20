using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cremeCoffeeBurgett.Models
{
    internal class SeedBeans : IEntityTypeConfiguration<Bean>
    {
        public void Configure(EntityTypeBuilder<Bean> entity)
        {
            entity.HasData(
                new Bean { BeanId = 1, Name = "Brazil", CountryId = "brazil", Price = 18.00 },
                new Bean { BeanId = 2, Name = "Burundi", CountryId = "burundi", Price = 19.50 },
                new Bean { BeanId = 3, Name = "Cold Brew Blend", CountryId = "blend", Price = 16.50 },
                new Bean { BeanId = 4, Name = "Columbia", CountryId = "columbia", Price = 17.50 },
                new Bean { BeanId = 5, Name = "Costa Rica", CountryId = "costa rica", Price = 17.99 },
                new Bean { BeanId = 6, Name = "Crimson Tide Blend", CountryId = "blend", Price = 16.50 },
                new Bean { BeanId = 7, Name = "Daylight Blend", CountryId = "blend", Price = 18.25 },
                new Bean { BeanId = 8, Name = "Decaf Columbia", CountryId = "columbia", Price = 17.50 },
                new Bean { BeanId = 9, Name = "Decaf Cost Rica", CountryId = "costa rica", Price = 17.99 },
                new Bean { BeanId = 10, Name = "Decaf Daylight Blend", CountryId = "blend", Price = 18.25 },
                new Bean { BeanId = 11, Name = "Ethiopa", CountryId = "ethiopa", Price = 19.75 },
                new Bean { BeanId = 12, Name = "French Roast", CountryId = "blend", Price = 17.00 },
                new Bean { BeanId = 13, Name = "Guatemala", CountryId = "guatemala", Price = 18.50 },
                new Bean { BeanId = 14, Name = "Hawaii Kona", CountryId = "usa", Price = 35.25 },
                new Bean { BeanId = 15, Name = "Honduras", CountryId = "honduras", Price = 18.50 },
                new Bean { BeanId = 16, Name = "Italian Roast", CountryId = "blend", Price = 16.50 },
                new Bean { BeanId = 17, Name = "Kenya", CountryId = "kenya", Price = 19.75 },
                new Bean { BeanId = 18, Name = "Mexico", CountryId = "mexico", Price = 18.50 },
                new Bean { BeanId = 19, Name = "Mexico Chiapas", CountryId = "mexico", Price = 19.99 },
                new Bean { BeanId = 20, Name = "Papua New Guinea", CountryId = "papua new guinea", Price = 19.75 },
                new Bean { BeanId = 21, Name = "Peru", CountryId = "peru", Price = 18.50 },
                new Bean { BeanId = 22, Name = "Rise and Shine Blend", CountryId = "blend", Price = 16.50 },
                new Bean { BeanId = 23, Name = "Rwanda", CountryId = "rwanda", Price = 19.99 },
                new Bean { BeanId = 24, Name = "Sunshine Blend", CountryId = "blend", Price = 16.75 },
                new Bean { BeanId = 25, Name = "Sulawesi", CountryId = "indonesia", Price = 19.50 },
                new Bean { BeanId = 26, Name = "Sumatra", CountryId = "indonesia", Price = 19.00 },
                new Bean { BeanId = 27, Name = "Tanzania", CountryId = "tanzania", Price = 21.00 },
                new Bean { BeanId = 28, Name = "Traders Blend", CountryId = "blend", Price = 16.75 },
                new Bean { BeanId = 29, Name = "Whiskey Barrel Aged Blend", CountryId = "blend", Price = 26.75 }
            );
        }
    }

}
