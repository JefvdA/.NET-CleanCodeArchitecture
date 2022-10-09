using Application.Interfaces;
using Domain.Models;

namespace Application.Services;

public class TodoItemService : ITodoItemService
{
    private readonly IUnitOfWork _unitOfWork;

    public TodoItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<TodoItem> GetAll(int pageNr, int pageSize)
    {
        return _unitOfWork.TodoItemRepository.GetAll(pageNr, pageSize);
    }

    public Task<TodoItem> GetById(int id)
    {
        return _unitOfWork.TodoItemRepository.GetById(id);
    }

    public async Task<TodoItem> Create(TodoItem newEntity)
    {
        _unitOfWork.TodoItemRepository.Create(newEntity);
        _unitOfWork.Commit();
        return newEntity;
    }

    public async Task<TodoItem> Update(TodoItem updatedEntity)
    {
        var existing = await _unitOfWork.TodoItemRepository.GetById(updatedEntity.Id);
        if (existing == null)
            throw new KeyNotFoundException("This TodoItem does not exist");

        existing.Description = updatedEntity.Description;
        _unitOfWork.Commit();
        return updatedEntity;
    }

    public async Task Delete(int id)
    {
        var existing = await _unitOfWork.TodoItemRepository.GetById(id);
        if (existing == null)
            throw new KeyNotFoundException("This TodoItem does not exist");
        
        _unitOfWork.TodoItemRepository.Delete(existing);
        _unitOfWork.Commit();
    }
}