using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Tasks.DTOs;
using TaskManager.Application.Features.Tasks.Interfaces;
using TaskManager.Domain.Enums;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // GET: api/tasks
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskService.GetAllAsync();
        return Ok(tasks);
    }

    // GET: api/tasks/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _taskService.GetByIdAsync(id);

        if (task == null)
            return NotFound($"Task with Id {id} was not found.");

        return Ok(task);
    }

    // GET: api/tasks/project/1
    [HttpGet("project/{projectId:int}")]
    public async Task<IActionResult> GetByProject(int projectId)
    {
        var tasks = await _taskService.GetByProjectIdAsync(projectId);
        return Ok(tasks);
    }

    // GET: api/tasks/status/ToDo
    // GET: api/tasks/status/InProgress
    // GET: api/tasks/status/Done
    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(TaskItemStatus status)
    {
        var tasks = await _taskService.GetByStatusAsync(status);
        return Ok(tasks);
    }

    // POST: api/tasks
    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var task = await _taskService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = task.Id },
            task);
    }

    // PUT: api/tasks/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _taskService.UpdateAsync(id, dto);

        if (!updated)
            return NotFound($"Task with Id {id} was not found.");

        return NoContent();
    }

    // DELETE: api/tasks/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _taskService.DeleteAsync(id);

        if (!deleted)
            return NotFound($"Task with Id {id} was not found.");

        return NoContent();
    }
}