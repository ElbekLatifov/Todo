using FluentValidation;
using TaskAPI.Models;

namespace TaskAPI.Validators
{
    public class TaskValidator : AbstractValidator<TaskModel>
    {
        public TaskValidator() 
        {
            RuleFor(x=>x.Deadline).NotEmpty().Must(p=>p > DateTime.Now);
            RuleFor(p=>p.Title).NotEmpty().MinimumLength(1).MaximumLength(50);
            RuleFor(p => p.Description).NotEmpty().MaximumLength(500);
        }

    }
}
