

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskManager.Domain.Entities; 

namespace TaskManager.Infraestructure.Data
{
    public class ApiDbContext : DbContext
    {
        public   DbSet<Activity> Activities { get; set; }
        public  DbSet<User> Users { get; set; }
        public   DbSet<Meet> Meets { get; set; }
        public   DbSet<SubTask> SubTasks { get; set; }


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

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseEntity.CreatedAt))
                        .HasDefaultValueSql("GETDATE()")
                        .ValueGeneratedOnAdd()
                        .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                    modelBuilder.Entity(entityType.ClrType)
                       .Property(nameof(BaseEntity.UpdatedAt))
                       .HasDefaultValueSql("GETDATE()")
                       .ValueGeneratedOnAddOrUpdate()
                       .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

                }
            }
            modelBuilder.Entity<User>().ToTable("user", schema: "dbo");
           
            modelBuilder.Entity<User>().Property(e => e.Id)
                                        .HasColumnName("userId");

            modelBuilder.Entity<Activity>()
     .ToTable("activity", schema: "dbo")
     .HasKey(e => e.Id); // Definir la clave primaria

            modelBuilder.Entity<Activity>()
                .Property(e => e.Id) // Especificar el tipo de la propiedad (int en este caso)
                .HasColumnName("ActivityId")
                .HasColumnType("int");




        }
    }
}
