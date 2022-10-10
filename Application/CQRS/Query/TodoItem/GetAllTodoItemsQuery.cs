using Application.Interfaces;
using MediatR;

namespace Application.CQRS.Query.TodoItem;

using Domain.Models;

public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItem>>
{
    public int PageNr { get; set; }
    public int PageSize { get; set; }

    public GetAllTodoItemsQuery()
    {
    }
}

public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItem>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTodoItemsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TodoItem>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TodoItemRepository.GetAll(request.PageNr, request.PageSize);
    }
} 