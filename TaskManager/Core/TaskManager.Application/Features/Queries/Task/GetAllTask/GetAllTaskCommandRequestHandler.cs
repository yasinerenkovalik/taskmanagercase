using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Interface.Repository;
using TaskManager.Application.Wrappers;

namespace TaskManager.Application.Features.Queries.Task.GetAllTask;

public class GetAllTaskCommandRequestHandler
    : IRequestHandler<GetAllTaskCommandRequest, GeneralResponse<List<GetAllTaskCommandResponse>>>
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllTaskCommandRequestHandler> _logger;

    public GetAllTaskCommandRequestHandler(
        ITaskItemRepository taskItemRepository,
        IMapper mapper,
        ILogger<GetAllTaskCommandRequestHandler> logger)
    {
        _taskItemRepository = taskItemRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GeneralResponse<List<GetAllTaskCommandResponse>>> Handle(
        GetAllTaskCommandRequest request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetAllTask işlemi başladı");

        try
        {
            var tasks = await _taskItemRepository.GetAllAysnc();

            if (tasks == null || !tasks.Any())
            {
                _logger.LogWarning("GetAllTask sonucu boş");

                return new GeneralResponse<List<GetAllTaskCommandResponse>>
                {
                    Data = new List<GetAllTaskCommandResponse>
                    {
                        
                    },
                    Message = "Herhangi bir task bulunamadı",
                    isSuccess = true
                };
            }

            var taskDtos = _mapper.Map<List<GetAllTaskCommandResponse>>(tasks);

          

            _logger.LogInformation(
                "GetAllTask başarılı. Toplam kayıt: {Count}",
                taskDtos.Count
            );

            return new GeneralResponse<List<GetAllTaskCommandResponse>>
            {
                Data = taskDtos,
                Message = "Tasklar başarıyla listelendi",
                isSuccess = true
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetAllTask sırasında hata oluştu");

            return new GeneralResponse<List<GetAllTaskCommandResponse>>
            {
                Data = null,
                Message = "Tasklar listelenirken hata oluştu",
                isSuccess = false
            };
        }
    }
}
