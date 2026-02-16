using Domain.Entities;

public class Label : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = "#000000";

    public ICollection<TaskLabel> TaskLabels { get; set; } = new List<TaskLabel>();
}
