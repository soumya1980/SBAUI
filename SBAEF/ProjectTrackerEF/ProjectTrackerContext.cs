using ProjectTrackerEF.Models;
using System.Data.Entity;

namespace ProjectTrackerEF
{
    public class ProjectTrackerContext : DbContext
    {
        public ProjectTrackerContext() : base()
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ParentTask> ParentTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
