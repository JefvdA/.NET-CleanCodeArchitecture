using Application.Interfaces;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly CleanCodeArchitectureDbContext _context;
    
    public TodoItemRepository(CleanCodeArchitectureDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TodoItem>> GetAll(int pageNr, int pageSize)
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoItem> GetById(int id)
    {
        return await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == id);
    }

    public TodoItem Create(TodoItem newEntity)
    {
        _context.TodoItems.Add(newEntity);
        return newEntity;
    }

    public TodoItem Update(TodoItem modifiedEntity)
    {
        _context.TodoItems.Update(modifiedEntity);
        return modifiedEntity;
    }

    public void Delete(TodoItem entity)
    {
        _context.TodoItems.Remove(entity);
    }
}