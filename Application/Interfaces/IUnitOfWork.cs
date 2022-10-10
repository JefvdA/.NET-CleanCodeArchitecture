namespace Application.Interfaces;

public interface IUnitOfWork
{
    public ITodoItemRepository TodoItemRepository { get; }

    Task Commit();
}