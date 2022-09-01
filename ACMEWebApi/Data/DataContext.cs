using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace ACMEWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
            // What DbContext does is represent a session with the database and it can be used to query
            // and save instances of your entities.
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
