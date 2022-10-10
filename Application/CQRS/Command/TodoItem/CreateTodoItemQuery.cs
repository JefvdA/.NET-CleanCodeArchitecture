using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Command.TodoItem;

using Domain.Models;

public class CreateTodoItemQuery : IRequest<TodoItem>
{
    public TodoItem NewTodoItem { get; set; } = new TodoItem();
}

public class CreateTodoItemQueryHandler : IRequestHandler<CreateTodoItemQuery, TodoItem>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateTodoItemQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TodoItem> Handle(CreateTodoItemQuery request, CancellationToken cancellationToken)
    {
        _unitOfWork.TodoItemRepository.Create(request.NewTodoItem);
        await _unitOfWork.Commit();
        return request.NewTodoItem;
    }
}