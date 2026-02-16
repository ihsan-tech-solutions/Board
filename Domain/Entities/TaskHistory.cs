using Domain.Entities;

public class TaskHistory : BaseEntity
{
    public Guid TaskId { get; set; }
    public Guid OldStatusId { get; set; }
    public Guid NewStatusId { get; set; }
}
