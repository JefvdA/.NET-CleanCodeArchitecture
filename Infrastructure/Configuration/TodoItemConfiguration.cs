using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("tblTodoItems", "TodoItem")
            .HasKey(t => t.Id);
        
        builder.HasIndex(t => t.Id)
            .IsUnique();
        builder.Property(t => t.Id)
            .HasColumnType("int");
        builder.Property(t  => t.Description)
            .IsRequired()
            .HasColumnType("nvarchar(120)");
    }
}