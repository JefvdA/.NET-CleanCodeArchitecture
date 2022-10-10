using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Query.TodoItem;

using Domain.Models;

public class GetTodoItemByIdQuery : IRequest<TodoItem>
{
    public int Id { get; set; }
}

public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItem>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTodoItemByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TodoItem> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TodoItemRepository.GetById(request.Id);
    }
}