using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<phonebook> PhonebookEntries { get; set; }
    }
}