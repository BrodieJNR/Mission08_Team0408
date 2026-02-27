using System.Linq;
using Mission08_Team0408.Models;

namespace Mission08_Team0408.Data
{
    public interface ITaskRepository
    {
        IQueryable<TaskItem> TaskItems { get; }

        TaskItem? GetTaskById(int id);

        void AddTask(TaskItem task);

        void UpdateTask(TaskItem task);

        void DeleteTask(TaskItem task);

        void SaveChanges();
    }
}