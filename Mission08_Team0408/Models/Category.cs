using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0408.Models
{
    // Represents a category like Home, School, Work, Church
    public class Category
    {
        // Primary Key
        public int CategoryId { get; set; }

        // Category name is required
        [Required]
        public string CategoryName { get; set; } = string.Empty;

        // One category can have many tasks
        public List<TaskItem> TaskItems { get; set; } = new();
    }
}