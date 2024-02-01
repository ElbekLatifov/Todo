using System.ComponentModel.DataAnnotations;
using TaskAPI.Entities;

namespace TaskAPI.Models
{
    public class TaskModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public State State { get; set; }
        [Required(ErrorMessage = "Deadline must be greast then now")]
        public DateTime Deadline { get; set; }
    }
}
