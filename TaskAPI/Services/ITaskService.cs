using TaskAPI.Entities;
using TaskAPI.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskAPI.Services
{
    public interface ITaskService
    {
        public Task<List<Entities.Task>> GetTasksAsync();
        public Task<Entities.Task> GetTaskByIdAsync(Guid id);
        public Task DeleteTaskAsync(Guid id);
        public Task UpdateTaskAsync(Guid id, TaskModel value);  
        public Task<Guid> AddTaskAsync(TaskModel value);
    }
}
