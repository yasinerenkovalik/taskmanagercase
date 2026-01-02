using AutoMapper;
using TaskManager.Application.Features.Commands.Task.UpdateTask;
using TaskManager.Application.Features.Commands.TaskItem;
using TaskManager.Application.Features.Queries.Task.GetAllTask;
using TaskManager.Application.Features.Queries.Task.GetByIdTask;
using Task = TaskManager.Domain.Entities.TaskItem;

namespace TaskManager.Application.Mapping;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskCommandRequest, Task>().ReverseMap();
        CreateMap<CreateTaskCommandResponse, Task>().ReverseMap();
        CreateMap<GetByIdTaskCommandResponse, Task>().ReverseMap();
        CreateMap<Task, GetAllTaskCommandRequest>().ReverseMap();
        CreateMap<Task, GetAllTaskCommandResponse>().ReverseMap();
        CreateMap<Task, UpdateTaskCommandRequest>().ReverseMap();
        CreateMap<Task, UpdateTaskCommandResponse>().ReverseMap();
        
    }
}