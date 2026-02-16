using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
                
        }
        public DbSet<WorkTask> Tasks => Set<WorkTask>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ActivityLog> ActivityLogs => Set<ActivityLog>();
        public DbSet<Attachment> Attachment => Set<Attachment>();
        public DbSet<AuditTrail> AuditTrail => Set<AuditTrail>();   
        public DbSet<Comment> comments => Set<Comment>();
        public DbSet<Label> labels => Set<Label>();
        public DbSet<Notification> notification => Set<Notification>(); 
        public DbSet<Organization> organization => Set<Organization>(); 
        public DbSet<PriorityEntity> priority => Set<PriorityEntity>();
        public DbSet<ProjectMember> projectMember => Set<ProjectMember>();
        public DbSet<RefreshToken> refreshToken => Set<RefreshToken>();
        public DbSet<Role> roles => Set<Role>();
        public DbSet<Setting> setting => Set<Setting>();    
        public DbSet<Status> status => Set<Status>();
        public DbSet<TaskAssignment> taskAssignment => Set<TaskAssignment>();
        public DbSet<TaskDependency> taskDependency => Set<TaskDependency>();   
        public DbSet<TaskHistory> taskHistory => Set<TaskHistory>();    
        public DbSet<TaskLabel> taskLabel => Set<TaskLabel>();
        public DbSet<Team> team => Set<Team>(); 
        public DbSet<TeamMember> teamMember => Set<TeamMember>();
        public DbSet<TimeEntry> timeEntry => Set<TimeEntry>();
        public DbSet<User> user => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<UserSession> userSession => Set<UserSession>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Existing configurations
            modelBuilder.ApplyConfiguration(new WorkTaskConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());

            // ✅ Composite keys for join tables
            modelBuilder.Entity<ProjectMember>()
                .HasKey(pm => new { pm.ProjectId, pm.UserId });

            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamId, tm.UserId });

            modelBuilder.Entity<TaskAssignment>()
                .HasKey(ta => new { ta.TaskId, ta.AssignedTo });

            modelBuilder.Entity<TaskLabel>()
                .HasKey(tl => new { tl.TaskId, tl.LabelId });
            modelBuilder.Entity<TaskDependency>()
      .HasKey(td => new { td.TaskId, td.DependsOnTaskId });
            modelBuilder.Entity<UserRole>()
     .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<TaskDependency>()
    .HasOne(td => td.Task)
    .WithMany(t => t.Dependencies)
    .HasForeignKey(td => td.TaskId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskDependency>()
                .HasOne(td => td.DependsOnTask)
                .WithMany()
                .HasForeignKey(td => td.DependsOnTaskId)
                .OnDelete(DeleteBehavior.Restrict);
            // ✅ Optional: Indexes or relationships (if needed)
            // modelBuilder.Entity<ProjectMember>()
            //     .HasOne(pm => pm.Project)
            //     .WithMany(p => p.ProjectMembers)
            //     .HasForeignKey(pm => pm.ProjectId);

            // modelBuilder.Entity<ProjectMember>()
            //     .HasOne(pm => pm.User)
            //     .WithMany(u => u.ProjectMemberships)
            //     .HasForeignKey(pm => pm.UserId);
        }


    }
}
