using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Command.TodoItems;

public class UpdateTodoItemCommand : IRequest<TodoItem>
{
    public TodoItem UpdatedTodoItem { get; set; } = new TodoItem();
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
        _unitOfWork.TodoItemRepository.Update(request.UpdatedTodoItem);
        await _unitOfWork.Commit();
        return request.UpdatedTodoItem;
    }
}