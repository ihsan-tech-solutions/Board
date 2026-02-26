using Domain.Entities;

public class Attachment : BaseEntity
{
    public Guid TaskId { get; set; }

    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public int FileSize { get; set; }

    public WorkTask Task { get; set; }
}
