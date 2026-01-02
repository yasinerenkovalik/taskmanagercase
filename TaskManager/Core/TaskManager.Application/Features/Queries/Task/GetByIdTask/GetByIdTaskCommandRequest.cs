using MediatR;
using TaskManager.Application.Wrappers;

namespace TaskManager.Application.Features.Queries.Task.GetByIdTask;

public class GetByIdTaskCommandRequest:IRequest<GeneralResponse<GetByIdTaskCommandResponse>>
{
    public Guid Id { get; set; }
}