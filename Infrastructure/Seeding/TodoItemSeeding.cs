using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Seeding;

public static class TodoItemSeeding
{
    public static void Seed(this EntityTypeBuilder<TodoItem> modelBuilder)
    {
        modelBuilder.HasData(
            new TodoItem
            {
                Id = -1,
                Description = "This is the first todo item",
            },
            new TodoItem
            {
                Id = -2,
                Description = "This is the second todo item",
            }
        );
    }
}