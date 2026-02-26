using Application.DTOs.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TasksController(ITaskRepository repository)
        {
            _repository = repository;
        }

        // =======================
        // CREATE TASK
        // =======================
        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskRequestDto dto)
        {
            var task = new WorkTask
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                Priority = dto.Priority
            };

            await _repository.AddAsync(task);

            var response = new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                CreatedAt = task.CreatedAt
            };

            return Ok(response);
        }

        // =======================
        // GET ALL TASKS
        // =======================
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _repository.GetAllAsync();

            var response = tasks
                .Where(t => !t.IsDeleted)
                .Select(t => new TaskResponseDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Priority = t.Priority,
                    CreatedAt = t.CreatedAt
                });

            return Ok(response);
        }

        // =======================
        // GET TASK BY ID
        // =======================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null || task.IsDeleted)
                return NotFound();

            var response = new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                CreatedAt = task.CreatedAt
            };

            return Ok(response);
        }

        // =======================
        // UPDATE TASK
        // =======================
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, UpdateTaskRequestDto dto)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null || task.IsDeleted)
                return NotFound();

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.DueDate = dto.DueDate;
            task.Priority = dto.Priority;
            task.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(task);

            var response = new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                CreatedAt = task.CreatedAt
            };

            return Ok(response);
        }

        // =======================
        // DELETE TASK (SOFT DELETE)
        // =======================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null || task.IsDeleted)
                return NotFound();

            task.IsDeleted = true;
            task.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(task);

            return Ok(new { message = "Task deleted successfully" });
        }
    }
}
