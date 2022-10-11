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
        var todoItem = await _unitOfWork.TodoItemRepository.GetById(request.UpdatedTodoItem.Id);

        if (todoItem == null)
            throw new KeyNotFoundException("This TodoItem does not exist!");
        
        todoItem.Description = request.UpdatedTodoItem.Description;
        
        _unitOfWork.TodoItemRepository.Update(todoItem);
        await _unitOfWork.Commit();
        return request.UpdatedTodoItem;
    }
}