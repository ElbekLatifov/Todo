using System.ComponentModel.DataAnnotations;
using TaskBlazor.Entities;

namespace TaskBlazor.Models
{
    public class TaskModel
    {
        [Required(ErrorMessage = "Enter the title :)")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public State State { get; set; }
        [Required(ErrorMessage = "Deadline must be greater than now!")]
        [DateLessThanOrEqualToToday]
        public DateTime? Deadline { get; set; }
    }

    public class DateLessThanOrEqualToToday : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "deadline should be greater than now";
        }

        protected override ValidationResult IsValid(object objValue,
                                                       ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();

            //alter this as needed. I am doing the date comparison if the value is not null

            if (dateValue.Date <= DateTime.Now.Date)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}
