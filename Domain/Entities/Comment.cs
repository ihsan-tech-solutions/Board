using Domain.Entities;

public class Comment : BaseEntity
{
    public Guid TaskId { get; set; }
    public string CommentText { get; set; } = string.Empty;

    public WorkTask Task { get; set; }
}
