using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class WorkTaskConfiguration : IEntityTypeConfiguration<WorkTask>
    {
        public void Configure(EntityTypeBuilder<WorkTask> builder)
        {
            builder.ToTable("Tasks");

            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.Description)
                   .HasMaxLength(2000);

            builder.Property(t => t.DueDate)
                   .IsRequired();

            builder.Property(t => t.Priority)
                   .IsRequired();

            // BaseEntity properties
            builder.Property(t => t.CreatedAt)
                   .IsRequired();

            builder.Property(t => t.UpdatedAt);

            builder.Property(t => t.IsDeleted)
                   .HasDefaultValue(false);
        }
    }
}
