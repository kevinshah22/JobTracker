using JobTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Data
{
    public class JobTrackerContext : DbContext
    {
        public JobTrackerContext()
        {

        }
        public JobTrackerContext(DbContextOptions<JobTrackerContext> options) : base(options)
        {

        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<JobApplication> JobApplications { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
