using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Multi_Page_Burgett.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        { }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Designation> Designations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>().HasData(
                new Contacts
                {
                    ContactsId = 1,
                    Name = "Ben Gates",
                    Phone = "123-456-7891",
                    Address = "123 Main Street, Anytown USA",
                    Note = "I met Ben while he was looking for a treasure map on the back of the Declaration of Independance.",
                    DesignationId = "Mr."
                },
                new Contacts
                {
                    ContactsId = 2,
                    Name = "Frodo Baggins",
                    Phone = "None",
                    Address = "Bag End, Bagshot Row, Hobbbiton, Shire ",
                    Note = "I met Frodo when he joined a fellowship to destroy a powerful ring",
                    DesignationId = "Hobbit"
                },
                new Contacts
                {
                    ContactsId = 3,
                    Name = "Angie Burgett",
                    Phone = "515-555-5555",
                    Address = "111 Myhouse Road, Des Moines Ia.",
                    Note = "Angie is my wife, I met her 22 years ago at a local coffee shop. She is truly my better half.",
                    DesignationId = "Mrs."
                }
            );
            modelBuilder.Entity<Designation>().HasData(
                new Designation { DesignationId = "Mr.", Name = "Mister" },
                new Designation { DesignationId = "Ms.", Name = "Miss" },
                new Designation { DesignationId = "Mrs.", Name = "Misses" },
                new Designation { DesignationId = "Hobbit", Name = "Hobbit" },
                new Designation { DesignationId = "Other", Name = "Other" }
            );
        }
    }
}
