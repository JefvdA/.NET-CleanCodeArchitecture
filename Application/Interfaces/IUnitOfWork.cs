namespace Application.Interfaces;

public interface IUnitOfWork
{
    public ITodoItemRepository TodoItemRepository { get; }

    void Commit();
}