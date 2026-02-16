using Domain.Entities;

public class Team : BaseEntity
{
    public Guid OrganizationId { get; set; }
    public string Name { get; set; } = string.Empty;
}
