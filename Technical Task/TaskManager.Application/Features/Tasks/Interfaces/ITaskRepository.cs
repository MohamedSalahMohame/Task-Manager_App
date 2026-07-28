using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Features.Tasks.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllAsync();

    Task<TaskItem?> GetByIdAsync(int id);

    Task AddAsync(TaskItem task);

    void Update(TaskItem task);

    void Delete(TaskItem task);

    Task SaveChangesAsync();

    Task<IEnumerable<TaskItem>> GetByProjectIdAsync(int projectId);

    Task<IEnumerable<TaskItem>> GetByStatusAsync(TaskItemStatus status);
}