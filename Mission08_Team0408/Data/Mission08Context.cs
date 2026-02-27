using Microsoft.EntityFrameworkCore;
using Mission08_Team0408.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Mission08_Team0408.Data
{
    // Connects our models to the database
    public class Mission08Context : DbContext
    {
        public Mission08Context(DbContextOptions<Mission08Context> options)
            : base(options)
        {
        }

        // These become tables
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define 1-to-many relationship
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Category)
                .WithMany(c => c.TaskItems)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed default categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
