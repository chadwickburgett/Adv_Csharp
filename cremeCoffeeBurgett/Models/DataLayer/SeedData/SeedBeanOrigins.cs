using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cremeCoffeeBurgett.Models
{
    internal class SeedBeanOrigins : IEntityTypeConfiguration<CoffeeOrigin>
    {
        public void Configure(EntityTypeBuilder<CoffeeOrigin> entity)
        {
            entity.HasData(
                new CoffeeOrigin { BeanId = 1, OriginId = 1 },
                new CoffeeOrigin { BeanId = 2, OriginId = 4 },
                new CoffeeOrigin { BeanId = 3, OriginId = 5 },
                new CoffeeOrigin { BeanId = 4, OriginId = 7 },
                new CoffeeOrigin { BeanId = 5, OriginId = 9 },
                new CoffeeOrigin { BeanId = 6, OriginId = 6 },
                new CoffeeOrigin { BeanId = 7, OriginId = 5 },
                new CoffeeOrigin { BeanId = 8, OriginId = 7 },
                new CoffeeOrigin { BeanId = 9, OriginId = 9 },
                new CoffeeOrigin { BeanId = 10, OriginId = 6 },
                new CoffeeOrigin { BeanId = 11, OriginId = 10 },
                new CoffeeOrigin { BeanId = 12, OriginId = 5 },
                new CoffeeOrigin { BeanId = 13, OriginId = 13 },
                new CoffeeOrigin { BeanId = 14, OriginId = 15 },
                new CoffeeOrigin { BeanId = 15, OriginId = 16 },
                new CoffeeOrigin { BeanId = 16, OriginId = 5 },
                new CoffeeOrigin { BeanId = 17, OriginId = 17 },
                new CoffeeOrigin { BeanId = 18, OriginId = 18 },
                new CoffeeOrigin { BeanId = 19, OriginId = 18 },
                new CoffeeOrigin { BeanId = 20, OriginId = 19 },
                new CoffeeOrigin { BeanId = 21, OriginId = 20 },
                new CoffeeOrigin { BeanId = 22, OriginId = 6 },
                new CoffeeOrigin { BeanId = 23, OriginId = 21 },
                new CoffeeOrigin { BeanId = 24, OriginId = 6 },
                new CoffeeOrigin { BeanId = 25, OriginId = 25 },
                new CoffeeOrigin { BeanId = 26, OriginId = 23 },
                new CoffeeOrigin { BeanId = 27, OriginId = 26 },
                new CoffeeOrigin { BeanId = 28, OriginId = 5 },
                new CoffeeOrigin { BeanId = 29, OriginId = 6 }
            );
        }
    }

}
