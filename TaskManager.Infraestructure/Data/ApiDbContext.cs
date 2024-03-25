

using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities; 

namespace TaskManager.Infraestructure.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<Activity> Activities { get; set; }
        public  DbSet<User> Users { get; set; }
        public virtual DbSet<Meet> Meets { get; set; }
        public virtual DbSet<SubTask> SubTasks { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("user", schema: "dbo");

        }
    }
}
