using System.ComponentModel.DataAnnotations;
using TaskBlazor.Entities;

namespace TaskBlazor.Models
{
    public class FormModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public State State { get; set; }
        [Required(ErrorMessage = "Enter date")]
        public DateTime Deadline { get; set; } = DateTime.Now;
        public bool IsDeadClick { get; set; } = false;
    }
}
