using Microsoft.EntityFrameworkCore;
using TodosBackend.Model;

namespace TodosBackend.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                new Todo() { Id=1, Name="Nhiem Vu 1", Iscomplete=false },
                new Todo() { Id=2, Name="Nhiem Vu 2", Iscomplete=false }
                );

        }
    }
}
