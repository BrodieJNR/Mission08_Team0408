using System.Linq;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0408.Models;

namespace Mission08_Team0408.Data
{
    public class EFTaskRepository : ITaskRepository
    {
        private readonly Mission08Context _context;

        public EFTaskRepository(Mission08Context context)
        {
            _context = context;
        }

        // Include Category so we can display CategoryName in views
        public IQueryable<TaskItem> TaskItems =>
            _context.TaskItems.Include(t => t.Category);

        public TaskItem? GetTaskById(int id) =>
            _context.TaskItems
                .Include(t => t.Category)
                .FirstOrDefault(t => t.TaskItemId == id);

        public void AddTask(TaskItem task)
        {
            _context.TaskItems.Add(task);
        }

        public void UpdateTask(TaskItem task)
        {
            _context.TaskItems.Update(task);
        }

        public void DeleteTask(TaskItem task)
        {
            _context.TaskItems.Remove(task);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}