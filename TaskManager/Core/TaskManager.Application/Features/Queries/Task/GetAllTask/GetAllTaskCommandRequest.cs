using MediatR;
using TaskManager.Application.Wrappers;

namespace TaskManager.Application.Features.Queries.Task.GetAllTask;

public class GetAllTaskCommandRequest:IRequest<GeneralResponse<List<GetAllTaskCommandResponse>>>
{
    
}