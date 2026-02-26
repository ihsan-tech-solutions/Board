using Domain.Entities;

public class TaskLabel
{
    public Guid TaskId { get; set; }
    public Guid LabelId { get; set; }

    public WorkTask Task { get; set; }
    public Label Label { get; set; }
}
