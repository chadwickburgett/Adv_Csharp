using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cremeCoffeeBurgett.Models
{
    internal class SeedOrigins : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> entity)
        {
            entity.HasData(
                new Origin { OriginId = 1, Name = "Brazil", Process = "Honey" },
                new Origin { OriginId = 2, Name = "Brazil", Process = "Washed" },
                new Origin { OriginId = 3, Name = "Burundi", Process = "Natural" },
                new Origin { OriginId = 4, Name = "Burundi", Process = "Honey" },
                new Origin { OriginId = 5, Name = "Blend", Process = "Natural" },
                new Origin { OriginId = 6, Name = "Blend", Process = "Washed" },
                new Origin { OriginId = 7, Name = "Columbia", Process = "Washed" },
                new Origin { OriginId = 8, Name = "Columbia", Process = "Natural" },
                new Origin { OriginId = 9, Name = "Costa Rica", Process = "Honey" },
                new Origin { OriginId = 10, Name = "Ethiopia", Process = "Honey" },
                new Origin { OriginId = 11, Name = "Ethiopia", Process = "Washed" },
                new Origin { OriginId = 12, Name = "Ethiopia", Process = "Natural" },
                new Origin { OriginId = 13, Name = "Guatemala", Process = "Honey" },
                new Origin { OriginId = 14, Name = "Guatemala", Process = "Natural" },
                new Origin { OriginId = 15, Name = "USA", Process = "Natural" },
                new Origin { OriginId = 16, Name = "Honduras", Process = "Washed" },
                new Origin { OriginId = 17, Name = "Kenya", Process = "Honey" },
                new Origin { OriginId = 18, Name = "Mexico", Process = "Washed" },
                new Origin { OriginId = 19, Name = "Papua New Guinea", Process = "Natural" },
                new Origin { OriginId = 20, Name = "Peru", Process = "Washed" },
                new Origin { OriginId = 21, Name = "Rwanda", Process = "Honey" },
                new Origin { OriginId = 22, Name = "Rwanda", Process = "Washed" },
                new Origin { OriginId = 23, Name = "Indonesia", Process = "Washed" },
                new Origin { OriginId = 25, Name = "Indonesia", Process = "Honey" },
                new Origin { OriginId = 26, Name = "Tanzania", Process = "Natural" }
            );
        }
    }

}