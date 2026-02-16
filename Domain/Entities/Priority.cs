using Domain.Entities;

public class PriorityEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }

    public ICollection<WorkTask> Tasks { get; set; } = new List<WorkTask>();
}