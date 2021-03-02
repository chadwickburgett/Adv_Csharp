using Microsoft.EntityFrameworkCore;

namespace dataTranferBurgett.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) 
            : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = "winter", Name = "Winter Olympics" },
                new Game { GameID = "summer", Name = "Summer Olympics" },
                new Game { GameID = "para", Name = "Paralympics" },
                new Game { GameID = "youth", Name = "Youth Olympic Games" }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "in", Name = "Indoor" },
                new Category { CategoryId = "out", Name = "Outdoor" }
                );
            modelBuilder.Entity<Sport>().HasData(
                new Sport { SportID = "Curl", Name = "Curling" },
                new Sport { SportID = "Bob", Name = "Bobsleigh" },
                new Sport { SportID = "Dive", Name = "Diving" },
                new Sport { SportID = "RC", Name = "Road Cycling" },
                new Sport { SportID = "Arch", Name = "Archery" },
                new Sport { SportID = "CS", Name = "Canoe Sprint" },
                new Sport { SportID = "Break", Name = "Breakdancing" },
                new Sport { SportID = "Skate", Name = "Skateboarding" }
                );
            modelBuilder.Entity<Country>().HasData(
                new { CountryID = "Cn", Name = "Canada", CategoryId = "in", SportID = "Curl", GameID = "winter", FlagImage = "canada.jpg" },
                new { CountryID = "Sw", Name = "Sweden", CategoryId = "in", SportID = "Curl", GameID = "winter", FlagImage = "sweden.jfif" },
                new { CountryID = "GB", Name = "Great Britain", CategoryId = "in", SportID = "Curl", GameID = "winter", FlagImage = "great_britain.jfif" },
                new { CountryID = "Jm", Name = "Jamaica", CategoryId = "out", SportID = "Bob", GameID = "winter", FlagImage = "jamaica.jfif" },
                new { CountryID = "It", Name = "Italy", CategoryId = "out", SportID = "Bob", GameID = "winter", FlagImage = "italy.jfif" },
                new { CountryID = "Jp", Name = "Japan", CategoryId = "out", SportID = "Bob", GameID = "winter", FlagImage = "japan.jfif" },
                new { CountryID = "Gm", Name = "Germany", CategoryId = "in", SportID = "Dive", GameID = "summer", FlagImage = "germany.jfif" },
                new { CountryID = "Ch", Name = "China", CategoryId = "in", SportID = "Dive", GameID = "summer", FlagImage = "china.jfif" },
                new { CountryID = "Mx", Name = "Mexico", CategoryId = "in", SportID = "Dive", GameID = "summer", FlagImage = "Mexico.jfif" },
                new { CountryID = "Bz", Name = "Brazil", CategoryId = "out", SportID = "RC", GameID = "summer", FlagImage = "brazil.jfif" },
                new { CountryID = "Nl", Name = "Netherlands", CategoryId = "out", SportID = "RC", GameID = "summer", FlagImage = "netherlands.jfif" },
                new { CountryID = "US", Name = "USA", CategoryId = "out", SportID = "RC", GameID = "summer", FlagImage = "USA.jfif" },
                new { CountryID = "Tl", Name = "Thailand", CategoryId = "in", SportID = "Arch", GameID = "para", FlagImage = "thailand.jfif" },
                new { CountryID = "Ug", Name = "Uruguay", CategoryId = "in", SportID = "Arch", GameID = "para", FlagImage = "uruguay.jfif" },
                new { CountryID = "Uk", Name = "Ukraine", CategoryId = "in", SportID = "Arch", GameID = "para", FlagImage = "Ukraine.jfif" },
                new { CountryID = "Au", Name = "Austria", CategoryId = "out", SportID = "CS", GameID = "para", FlagImage = "Austria.jfif" },
                new { CountryID = "Pk", Name = "Pakistan", CategoryId = "out", SportID = "CS", GameID = "para", FlagImage = "Pakistan.jfif" },
                new { CountryID = "Zm", Name = "Zimbabwe", CategoryId = "out", SportID = "CS", GameID = "para", FlagImage = "Zimbabwe.jfif" },
                new { CountryID = "Fc", Name = "France", CategoryId = "in", SportID = "Break", GameID = "youth", FlagImage = "France.jfif" },
                new { CountryID = "Cy", Name = "Cyprus", CategoryId = "in", SportID = "Break", GameID = "youth", FlagImage = "Cyprus.jfif" },
                new { CountryID = "Rs", Name = "Russia", CategoryId = "in", SportID = "Break", GameID = "youth", FlagImage = "Russia.jfif" },
                new { CountryID = "Fl", Name = "Finland", CategoryId = "out", SportID = "Skate", GameID = "youth", FlagImage = "Finland.jfif" },
                new { CountryID = "Sv", Name = "Slovakia", CategoryId = "out", SportID = "Skate", GameID = "youth", FlagImage = "Slovakia.jfif" },
                new { CountryID = "Pg", Name = "Portugal", CategoryId = "out", SportID = "Skate", GameID = "youth", FlagImage = "Portugal.jfif" }
                );
        }
    }
}
