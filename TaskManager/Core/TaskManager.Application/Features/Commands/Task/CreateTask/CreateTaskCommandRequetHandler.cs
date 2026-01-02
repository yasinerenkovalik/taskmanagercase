using AutoMapper;

using MediatR;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Interface.Repository;
using TaskManager.Application.Wrappers;
using Task = TaskManager.Domain.Entities.TaskItem;

namespace TaskManager.Application.Features.Commands.TaskItem;

public class CreateTaskCommandRequestHandler
    : IRequestHandler<CreateTaskCommandRequest, GeneralResponse<CreateTaskCommandResponse>>
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly ILogger<CreateTaskCommandRequestHandler> _logger;
    private readonly IMapper _mapper;

    public CreateTaskCommandRequestHandler(
        ITaskItemRepository taskItemRepository,
        IMapper mapper,
        ILogger<CreateTaskCommandRequestHandler> logger)
    {
        _taskItemRepository = taskItemRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GeneralResponse<CreateTaskCommandResponse>> Handle(
        CreateTaskCommandRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "CreateTaskCommand başladı. Title: {Title}", request.Title);
            
        var taskEntity = _mapper.Map<Domain.Entities.TaskItem>(request);
       
        await _taskItemRepository.AddAsync(taskEntity);

        var responseDto = _mapper.Map<CreateTaskCommandResponse>(taskEntity);

        _logger.LogInformation(
            "Task başarıyla oluşturuldu. TaskId: {TaskId}", taskEntity.Id);

        return new GeneralResponse<CreateTaskCommandResponse>
        {
            Data = responseDto,
            Message = "Başarıyla oluşturuldu",
            isSuccess = true
        };
    }
}
