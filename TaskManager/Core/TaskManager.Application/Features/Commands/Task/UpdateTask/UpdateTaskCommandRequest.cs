using MediatR;
using TaskManager.Application.Wrappers;

namespace TaskManager.Application.Features.Commands.Task.UpdateTask;

public class UpdateTaskCommandRequest:IRequest<GeneralResponse<UpdateTaskCommandResponse>>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public TaskStatus Status { get; set; } 
   
}