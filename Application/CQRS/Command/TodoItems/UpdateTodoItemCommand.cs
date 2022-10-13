using Application.Interfaces;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.CQRS.Command.TodoItems;

public class UpdateTodoItemCommand : IRequest<TodoItem>
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public bool Done { get; set; }
}

public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Description).NotEmpty().MaximumLength(15);
        RuleFor(x => x.Done).NotEmpty();
    }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, TodoItem>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTodoItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TodoItem> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _unitOfWork.TodoItemRepository.GetById(request.Id);

        if (todoItem == null)
            throw new KeyNotFoundException("This TodoItem does not exist!");
        
        todoItem.Description = request.Description;
        todoItem.Done = request.Done;
        
        _unitOfWork.TodoItemRepository.Update(todoItem);
        await _unitOfWork.Commit();
        return todoItem;
    }
}