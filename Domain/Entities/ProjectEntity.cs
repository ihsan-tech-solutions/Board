
    namespace Domain.Entities
    {
        public class Project : BaseEntity
        {
            public string Name { get; set; } = string.Empty;

            public string ClientName { get; set; } = string.Empty;

            public DateTime StartDate { get; set; }

            public DateTime? EndDate { get; set; }
        }
    }

