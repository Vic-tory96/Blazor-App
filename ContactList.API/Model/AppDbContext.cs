using ContactBookModels;
using Microsoft.EntityFrameworkCore;

namespace ContactList.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Contact Table
            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ContactId = 1,
                FirstName = "Roman",
                LastName = "Reign",
                Email = "roman@wwecorp.com",
                PhoneNumber = "08035003025",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1985, 5, 25),
                Address = "Leati Joseph, Pensacola Florida",
                Occupation = "Wrestler",
                PhotoPath = "images/reignwwe.jpg"
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ContactId = 2,
                FirstName = "Sara",
                LastName = "Field",
                Email = "sara@yahoo.com",
                PhoneNumber = "08028961586",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(1979, 11, 11),
                Occupation = "Doctor",
                Address = "Uyo Street, Port Harcourt",
                PhotoPath = "images/sara.png"
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ContactId = 3,
                FirstName = "Victor",
                LastName = "Unachukwu",
                Email = "victor@gmail.com",
                DateOfBirth = new DateTime(1995, 5, 16),
                PhoneNumber = "09025419260",
                Gender = Gender.Male,
                Occupation = "Software Engineer",
                Address = "Asanjo, Lagos",
                PhotoPath = "images/victor.jpg"
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ContactId = 4,
                FirstName = "Ronda",
                LastName = "Rousey",
                Email = "ronda@wwecorp.com",
                DateOfBirth = new DateTime(1987, 1, 2),
                PhoneNumber = "08037530139",
                Gender = Gender.Female,
                Occupation = "Wrestler",
                Address = "Riverside, Califor nia",
                PhotoPath = "images/rosey.jpg"
            });
        }

    }
}

