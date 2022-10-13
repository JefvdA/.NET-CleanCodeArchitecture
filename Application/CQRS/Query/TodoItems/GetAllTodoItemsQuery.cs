using Application.CQRS.DTOs.TodoItems;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.CQRS.Query.TodoItems;

using Domain.Models;

public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItemDTO>>
{
    public int PageNr { get; set; }
    public int PageSize { get; set; }
}

public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItemDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllTodoItemsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TodoItemDTO>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.TodoItemRepository.GetAll(request.PageNr, request.PageSize);
        return _mapper.Map<IEnumerable<TodoItemDTO>>(list);
    }
} 