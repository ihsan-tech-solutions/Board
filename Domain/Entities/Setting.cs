using Domain.Entities;

public class Setting : BaseEntity
{
    public string KeyName { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
