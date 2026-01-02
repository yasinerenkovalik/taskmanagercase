using FluentValidation;

using TaskManager.Application.Features.Commands.TaskItem;

namespace TaskManager.Application.Validations.Company;

public class TaskCreateValidator : AbstractValidator<CreateTaskCommandRequest>
{
    public TaskCreateValidator()
    {
      
        RuleFor(x => x.Title).NotEmpty();
    }
}



