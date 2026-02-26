using Domain.Entities;

public class Status : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int OrderIndex { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<WorkTask> Tasks { get; set; } = new List<WorkTask>();
}