namespace Application.CQRS.DTOs.TodoItems;

public class TodoItemDetailedDTO
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public bool Done { get; set; }
}