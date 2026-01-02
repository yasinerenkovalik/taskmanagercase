using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Interface.Repository;
using TaskManager.Application.Wrappers;

namespace TaskManager.Application.Features.Commands.Task.UpdateTask;

public class UpdateTaskCommandRequestHandler
    : IRequestHandler<UpdateTaskCommandRequest, GeneralResponse<UpdateTaskCommandResponse>>
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateTaskCommandRequestHandler> _logger;

    public UpdateTaskCommandRequestHandler(
        ITaskItemRepository taskItemRepository,
        IMapper mapper,
        ILogger<UpdateTaskCommandRequestHandler> logger)
    {
        _taskItemRepository = taskItemRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GeneralResponse<UpdateTaskCommandResponse>> Handle(
        UpdateTaskCommandRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "UpdateTask işlemi başladı. TaskId: {TaskId}",
            request.Id
        );

        try
        {
            var taskEntity = await _taskItemRepository.GetByIdAsync(request.Id);

            if (taskEntity == null)
            {
                _logger.LogWarning(
                    "UpdateTask başarısız. Task bulunamadı. TaskId: {TaskId}",
                    request.Id
                );

                return new GeneralResponse<UpdateTaskCommandResponse>
                {
                    Data = null,
                    Message = "Task bulunamadı",
                    isSuccess = false
                };
            }

            // Map request → entity
            _mapper.Map(request, taskEntity);

            await _taskItemRepository.UpdateAsync(taskEntity);

            _logger.LogInformation(
                "Task başarıyla güncellendi. TaskId: {TaskId}",
                request.Id
            );

            var responseDto = _mapper.Map<UpdateTaskCommandResponse>(taskEntity);

            return new GeneralResponse<UpdateTaskCommandResponse>
            {
                Data = responseDto,
                Message = "Task başarıyla güncellendi",
                isSuccess = true
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "UpdateTask sırasında hata oluştu. TaskId: {TaskId}",
                request.Id
            );

            return new GeneralResponse<UpdateTaskCommandResponse>
            {
                Data = null,
                Message = "Task güncellenirken bir hata oluştu",
                isSuccess = false
            };
        }
    }
}
