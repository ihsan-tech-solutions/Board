using Domain.Entities;

public class Notification : BaseEntity
{
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
}
