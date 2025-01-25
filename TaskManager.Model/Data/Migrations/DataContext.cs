


using Microsoft.EntityFrameworkCore;
using TaskManager.Model.Entities;

namespace TaskManager.Model.Data.Migrations
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Tasks> Tasks { get; set; } 
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Tasks primary key
            modelBuilder.Entity<Tasks>()
                .HasKey(t => t.TaskId);

            // Optional: Configure relationships
            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tasks>()
                .HasOne(t => t.State)
                .WithMany()
                .HasForeignKey(t => t.StateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
