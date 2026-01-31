using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<WorkTask> Tasks => Set<WorkTask>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkTaskConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
