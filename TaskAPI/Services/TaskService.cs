using Microsoft.EntityFrameworkCore;
using TaskAPI.Context;
using TaskAPI.Models;

namespace TaskAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<Guid> AddTaskAsync(TaskModel value)
        {
            Entities.Task task = new Entities.Task()
            {
                Title = value.Title,
                Description = value.Description,
                Deadline = value.Deadline,
                Priority = value.Priority,
                State = value.State
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(Guid id)
        {
            Entities.Task task = await _context.Tasks.FirstAsync(p => p.Id == id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<Entities.Task> GetTaskByIdAsync(Guid id)
        {
            Entities.Task task = await _context.Tasks.FirstAsync(p=>p.Id == id);
            return task;
        }

        public async Task<List<Entities.Task>> GetTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(Guid id, TaskModel value)
        {
            Entities.Task oldtask = await _context.Tasks.FirstAsync(p => p.Id == id);
            oldtask.Title = value.Title;
            oldtask.Description = value.Description;
            oldtask.Deadline = value.Deadline      ;
            oldtask.Priority = value.Priority      ;
            oldtask.State = value.State;
            _context.Tasks.Update(oldtask);
            await _context.SaveChangesAsync();
        }
    }
}
