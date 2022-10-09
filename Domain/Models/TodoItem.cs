namespace Domain.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string Description { get; set; } = "";

    public TodoItem()
    {
    }
    public TodoItem(int id, string description)
    {
        Id = id;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Id} : {Description}";
    }
}