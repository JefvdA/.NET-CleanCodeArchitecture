using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Command.TodoItem;

using Domain.Models;

public class UpdateTodoItemQuery : IRequest<TodoItem>
{
    public TodoItem UpdatedTodoItem { get; set; } = new TodoItem();
}

public class UpdateTodoItemQueryHandler : IRequestHandler<UpdateTodoItemQuery, TodoItem>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTodoItemQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TodoItem> Handle(UpdateTodoItemQuery request, CancellationToken cancellationToken)
    {
        _unitOfWork.TodoItemRepository.Update(request.UpdatedTodoItem);
        await _unitOfWork.Commit();
        return request.UpdatedTodoItem;
    }
}