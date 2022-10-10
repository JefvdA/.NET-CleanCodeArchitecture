using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Command.TodoItem;

using Domain.Models;

public class DeleteTodoItemQuery : IRequest<TodoItem>
{
    public int Id { get; set; }
}

public class DeleteTodoItemQueryHandler : IRequestHandler<DeleteTodoItemQuery, TodoItem>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteTodoItemQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TodoItem> Handle(DeleteTodoItemQuery request, CancellationToken cancellationToken)
    {
        var todoItem = await _unitOfWork.TodoItemRepository.GetById(request.Id);
        _unitOfWork.TodoItemRepository.Delete(todoItem);
        await _unitOfWork.Commit();
        return todoItem;
    }
}