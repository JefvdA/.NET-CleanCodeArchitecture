using Application.Interfaces;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Command.TodoItems;

public class CreateTodoItemCommand : IRequest<TodoItem>
{
    public string Description { get; set; } = "";
    public bool Done { get; set; }
}

public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(15);
    }
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
        var todoItem = new TodoItem()
        {
            Description = request.Description,
            Done = request.Done
        };
        
        _unitOfWork.TodoItemRepository.Create(todoItem);
        await _unitOfWork.Commit();
        return todoItem;
    }
}