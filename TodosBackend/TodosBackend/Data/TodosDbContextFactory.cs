using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TodosBackend.Data
{
    public class TodosDbContextFactory : IDesignTimeDbContextFactory<TodosDbContext>
    {

        public TodosDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings")
                .Build();
            var connectionString = configurationRoot.GetConnectionString("TodoDatabase");
            var optionBuilder = new DbContextOptionsBuilder<TodosDbContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new TodosDbContext(optionBuilder.Options);
        }
    }
}
