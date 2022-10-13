using Application.CQRS.DTOs.TodoItems;
using AutoMapper;
using Domain.Models;

namespace Application;

public class Mappings : Profile
{
    public Mappings()
    {
        // TodoItems
        CreateMap<TodoItem, TodoItemDTO>();
        CreateMap<TodoItem, TodoItemDetailedDTO>();
    }
}