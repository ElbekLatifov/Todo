using TaskAPI.Entities;

namespace TaskAPI.Models
{
    public class TaskModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public State State { get; set; }
        public DateTime Deadline { get; set; }
    }
}
