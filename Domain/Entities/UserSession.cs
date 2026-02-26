using Domain.Entities;

public class UserSession : BaseEntity
{
    public Guid UserId { get; set; }

    public DateTime LoginTime { get; set; }
    public DateTime? LogoutTime { get; set; }

    public string IpAddress { get; set; } = string.Empty;
}
