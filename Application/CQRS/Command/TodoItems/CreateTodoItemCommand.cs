using Application.Interfaces;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Command.TodoItems;

public class CreateTodoItemCommand : IRequest<TodoItem>
{
    public TodoItem NewTodoItem { get; set; } = new TodoItem();
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, TodoItem>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateTodoItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TodoItem> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.TodoItemRepository.Create(request.NewTodoItem);
        await _unitOfWork.Commit();
        return request.NewTodoItem;
    }
}