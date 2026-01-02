using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Interface.Repository;
using TaskManager.Application.Wrappers;

namespace TaskManager.Application.Features.Queries.Task.GetByIdTask;

public class GetByIdTaskCommandRequestHandler
    : IRequestHandler<GetByIdTaskCommandRequest, GeneralResponse<GetByIdTaskCommandResponse>>
{
    private readonly ITaskItemRepository _taskRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetByIdTaskCommandRequestHandler> _logger;

    public GetByIdTaskCommandRequestHandler(
        ITaskItemRepository taskRepository,
        IMapper mapper,
        ILogger<GetByIdTaskCommandRequestHandler> logger)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GeneralResponse<GetByIdTaskCommandResponse>> Handle(
        GetByIdTaskCommandRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "GetByIdTask başladı. TaskId: {TaskId}", request.Id);

        var taskEntity = await _taskRepository.GetByIdAsync(request.Id);

        if (taskEntity == null || !taskEntity.IsActivated)
        {
            _logger.LogWarning(
                "Task bulunamadı. TaskId: {TaskId}", request.Id);

            return new GeneralResponse<GetByIdTaskCommandResponse>
            {
                Data = null,
                isSuccess = false,
                Message = "Task bulunamadı"
            };
        }

        var responseDto = _mapper.Map<GetByIdTaskCommandResponse>(taskEntity);

        _logger.LogInformation(
            "GetByIdTask başarılı. TaskId: {TaskId}", taskEntity.Id);

        return new GeneralResponse<GetByIdTaskCommandResponse>
        {
            Data = responseDto,
            isSuccess = true,
            Message = "Task başarıyla getirildi"
        };
    }
}