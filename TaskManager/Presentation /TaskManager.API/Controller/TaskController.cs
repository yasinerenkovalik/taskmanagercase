using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Commands.Task.UpdateTask;
using TaskManager.Application.Features.Commands.TaskItem;
using TaskManager.Application.Features.Queries.Task.GetAllTask;
using TaskManager.Application.Features.Queries.Task.GetByIdTask;

namespace TaskManager.Presentation.Controller
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ✅ GET /api/tasks
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var query = new GetAllTaskCommandRequest();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // ✅ GET /api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var query = new GetByIdTaskCommandRequest
            {
                Id = id
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // ✅ POST /api/tasks
        [HttpPost]
        public async Task<IActionResult> CreateTask(
            [FromBody] CreateTaskCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // ✅ PUT /api/tasks/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateTaskStatus(
            Guid id,
            [FromBody] UpdateTaskCommandRequest request)
        {
            request.Id = id;
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}