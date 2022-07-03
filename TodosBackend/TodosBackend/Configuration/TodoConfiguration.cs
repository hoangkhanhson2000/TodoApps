using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodosBackend.Model;

namespace TodosBackend.Configuration
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("todos");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Iscomplete).IsRequired().HasDefaultValue(false);
        }
    }
}
