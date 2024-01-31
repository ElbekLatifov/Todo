using System.ComponentModel.DataAnnotations;
using TaskBlazor.Entities;

namespace TaskBlazor.Models
{
    public class TaskModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public State State { get; set; }
        public DateTime Deadline { get; set; } = DateTime.Now;
    }
}
