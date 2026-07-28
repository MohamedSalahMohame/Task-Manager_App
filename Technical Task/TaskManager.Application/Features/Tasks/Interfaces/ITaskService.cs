using TaskManager.Application.Features.Tasks.DTOs;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Features.Tasks.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskDto>> GetAllAsync();

    Task<TaskDto?> GetByIdAsync(int id);

    Task<TaskDto> CreateAsync(CreateTaskDto dto);

    Task<bool> UpdateAsync(int id, UpdateTaskDto dto);

    Task<bool> DeleteAsync(int id);


    Task<IEnumerable<TaskDto>> GetByProjectIdAsync(int projectId);

    Task<IEnumerable<TaskDto>> GetByStatusAsync(TaskItemStatus status);
}