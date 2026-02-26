namespace Domain.Entities
{
    public class AuditTrail : BaseEntity
    {
        public string TableName { get; set; }
        public Guid RecordId { get; set; }
        public string Action { get; set; }
        public Guid? ChangedBy { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
