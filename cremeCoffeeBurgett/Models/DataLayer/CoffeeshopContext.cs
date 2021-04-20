using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;


namespace cremeCoffeeBurgett.Models
{
    public class CoffeeshopContext : IdentityDbContext<User>
    {
        public CoffeeshopContext(DbContextOptions<CoffeeshopContext> options)
            : base(options)
        { }

        public DbSet<Origin> Origins { get; set; }
        public DbSet<Bean> Beans { get; set; }
        public DbSet<CoffeeOrigin> BeanOrigins { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CoffeeOrigin>().HasKey(ba => new { ba.BeanId, ba.OriginId });
 
            modelBuilder.Entity<CoffeeOrigin>().HasOne(ba => ba.Bean)
                .WithMany(b => b.CoffeeOrigins)
                .HasForeignKey(ba => ba.BeanId);
            modelBuilder.Entity<CoffeeOrigin>().HasOne(ba => ba.Origin)
                .WithMany(a => a.CoffeeOrigins)
                .HasForeignKey(ba => ba.OriginId);

            modelBuilder.Entity<Bean>().HasOne(b => b.Country)
                .WithMany(g => g.Beans)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfiguration(new SeedCountries());
            modelBuilder.ApplyConfiguration(new SeedBeans());
            modelBuilder.ApplyConfiguration(new SeedOrigins());
            modelBuilder.ApplyConfiguration(new SeedBeanOrigins());
        }

        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Sesame";
            string roleName = "Admin";

            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

    }
}