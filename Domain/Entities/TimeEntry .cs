using Domain.Entities;

public class TimeEntry : BaseEntity
{
    public Guid TaskId { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int DurationMinutes { get; set; }

    public WorkTask Task { get; set; }
}
