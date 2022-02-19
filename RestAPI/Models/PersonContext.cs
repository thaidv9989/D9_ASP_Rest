using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<PersonModel> Persons { get; set; }
    }
}
