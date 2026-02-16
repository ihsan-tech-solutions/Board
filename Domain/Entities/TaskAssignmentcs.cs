using Domain.Entities;

public class TaskAssignment
{
    public Guid TaskId { get; set; }
    public Guid AssignedTo { get; set; }
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;

    public WorkTask Task { get; set; }
}