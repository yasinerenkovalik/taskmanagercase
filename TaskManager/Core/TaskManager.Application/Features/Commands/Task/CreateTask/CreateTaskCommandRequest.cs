
using MediatR;
using TaskManager.Application.Wrappers;

namespace TaskManager.Application.Features.Commands.TaskItem;

public class CreateTaskCommandRequest:IRequest<GeneralResponse<CreateTaskCommandResponse>>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public TaskStatus Status { get; set; } 
    public bool IsDeleted { get; set; } = false;
}