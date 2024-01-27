using System.ComponentModel.DataAnnotations;

namespace TaskBlazor.Entities
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
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
