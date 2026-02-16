using Domain.Entities;

public class TaskDependency
{
    public Guid TaskId { get; set; }
    public Guid DependsOnTaskId { get; set; }

    public WorkTask Task { get; set; }
    public WorkTask DependsOnTask { get; set; }
}
