using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public State State { get; set; }
        public DateTime Deadline { get; set; }
    }

    public enum State
    {
        Running,
        Expired,
        InProgress,
        Completed
    }
}
