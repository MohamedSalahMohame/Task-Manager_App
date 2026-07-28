using TaskManager.Application.Features.Projects.Interfaces;
using TaskManager.Application.Features.Tasks.DTOs;
using TaskManager.Application.Features.Tasks.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Features.Tasks.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public TaskService(
        ITaskRepository taskRepository,
        IProjectRepository projectRepository)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<TaskDto>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();

        return tasks.Select(task => new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status,
            ProjectId = task.ProjectId
        });
    }

    public async Task<TaskDto?> GetByIdAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task is null)
            return null;

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status,
            ProjectId = task.ProjectId
        };
    }

    public async Task<TaskDto> CreateAsync(CreateTaskDto dto)
    {
        var project = await _projectRepository.GetByIdAsync(dto.ProjectId);

        if (project is null)
            throw new Exception("Project not found.");

        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Status = dto.Status,
            ProjectId = dto.ProjectId
        };

        await _taskRepository.AddAsync(task);
        await _taskRepository.SaveChangesAsync();

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status,
            ProjectId = task.ProjectId
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateTaskDto dto)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task is null)
            return false;

        task.Title = dto.Title;
        task.Description = dto.Description;
        task.DueDate = dto.DueDate;
        task.Status = dto.Status;

        _taskRepository.Update(task);
        await _taskRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);

        if (task is null)
            return false;

        _taskRepository.Delete(task);
        await _taskRepository.SaveChangesAsync();

        return true;
    }


    public async Task<IEnumerable<TaskDto>> GetByProjectIdAsync(int projectId)
    {
        var tasks = await _taskRepository.GetByProjectIdAsync(projectId);

        return tasks.Select(task => new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status,
            ProjectId = task.ProjectId
        });
    }

    public async Task<IEnumerable<TaskDto>> GetByStatusAsync(TaskItemStatus status)
    {
        var tasks = await _taskRepository.GetByStatusAsync(status);

        return tasks.Select(task => new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status,
            ProjectId = task.ProjectId
        });
    }
}