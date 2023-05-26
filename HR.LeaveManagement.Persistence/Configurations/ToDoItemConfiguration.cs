using Blazor.Clean.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Blazor.Clean.Persistence.Configurations
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.HasData(
                new ToDoItem
                {
                    Id = 1,
                    Description = "Do Awesome Stuff",
                    IsCompleted = false,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            );

            builder.Property(q => q.Description)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}