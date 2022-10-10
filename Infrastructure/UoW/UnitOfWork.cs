using Application.Interfaces;
using Infrastructure.Contexts;

namespace Infrastructure.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly CleanCodeArchitectureDbContext _context;
    
    public ITodoItemRepository TodoItemRepository { get; }

    public UnitOfWork(CleanCodeArchitectureDbContext context, ITodoItemRepository todoItemRepository)
    {
        _context = context;
        TodoItemRepository = todoItemRepository;
    }

    public Task Commit()
    {
        return _context.SaveChangesAsync();
    }
}