using Microsoft.EntityFrameworkCore;
using TodosBackend.Configuration;
using TodosBackend.Seeders;

namespace TodosBackend.Data
{
    public class TodosDbContext:DbContext
    {
        public TodosDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
            modelBuilder.Seed();

        }

    }
    
}
