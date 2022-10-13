namespace Domain.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public bool Done { get; set; }

    public TodoItem()
    {
    }
    public TodoItem(int id, string description, bool done)
    {
        Id = id;
        Description = description;
        Done = done;
    }

    public override string ToString()
    {
        return $"{Id} : {Description} - Completed?: {Done}";
    }
}