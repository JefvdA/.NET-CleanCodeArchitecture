using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Command.TodoItems;

public class DeleteTodoItemCommand: IRequest<TodoItem>
{
    public int Id { get; set; }
}

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, TodoItem>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteTodoItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<TodoItem> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _unitOfWork.TodoItemRepository.GetById(request.Id);
        _unitOfWork.TodoItemRepository.Delete(todoItem);
        await _unitOfWork.Commit();
        return todoItem;
    }
}