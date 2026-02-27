using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08_Team0408.Data;
using Mission08_Team0408.Models;

namespace Mission08_Team0408.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repository;
        private readonly Mission08Context _context;

        public TaskController(ITaskRepository repository, Mission08Context context)
        {
            _repository = repository;
            _context = context;
        }

        // GET /Task/Quadrants
        public IActionResult Quadrants()
        {
            var tasks = _repository?.TaskItems?.Where(t => !t.Completed).ToList() ?? new List<TaskItem>();
            return View(tasks);
        }


        // GET /Task/Add
        public IActionResult Add()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View("TaskForm", new TaskItem());
        }

        // POST /Task/Add
        [HttpPost]
        public IActionResult Add(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _repository.AddTask(taskItem);
                _repository.SaveChanges();
                return RedirectToAction("Quadrants");
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View("TaskForm", taskItem);
        }

        // GET /Task/Edit/{id}
        public IActionResult Edit(int id)
        {
            var task = _repository.GetTaskById(id);
            if (task == null) return NotFound();
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", task.CategoryId);
            return View("TaskForm", task);
        }

        // POST /Task/Edit
        [HttpPost]
        public IActionResult Edit(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateTask(taskItem);
                _repository.SaveChanges();
                return RedirectToAction("Quadrants");
            }
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName", taskItem.CategoryId);
            return View("TaskForm", taskItem);
        }

        // POST /Task/Delete/{id}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = _repository.GetTaskById(id);
            if (task != null)
            {
                _repository.DeleteTask(task);
                _repository.SaveChanges();
            }
            return RedirectToAction("Quadrants");
        }

        // POST /Task/MarkComplete/{id}
        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            var task = _repository.GetTaskById(id);
            if (task != null)
            {
                task.Completed = true;
                _repository.UpdateTask(task);
                _repository.SaveChanges();
            }
            return RedirectToAction("Quadrants");
        }
    }
}
