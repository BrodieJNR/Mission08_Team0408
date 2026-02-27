using System;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0408.Models
{
    // Represents a task in the quadrant system
    public class TaskItem
    {
        // Primary Key
        public int TaskItemId { get; set; }

        // Task description (required)
        [Required]
        public string Task { get; set; } = string.Empty;

        // Optional due date
        public DateTime? DueDate { get; set; }

        // Quadrant must be 1-4
        [Required]
        [Range(1, 4)]
        public int Quadrant { get; set; }

        // Starts incomplete
        public bool Completed { get; set; } = false;

        // Foreign Key to Category
        [Required]
        public int CategoryId { get; set; }

        // Navigation property
        public Category? Category { get; set; }
    }
}