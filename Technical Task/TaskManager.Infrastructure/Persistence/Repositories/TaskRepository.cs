using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Features.Tasks.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistence.Context;
using TaskManager.Domain.Enums;

namespace TaskManager.Infrastructure.Persistence.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.Tasks
            .Include(t => t.Project)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(TaskItem task)
    {
        await _context.Tasks.AddAsync(task);
    }

    public void Update(TaskItem task)
    {
        _context.Tasks.Update(task);
    }

    public void Delete(TaskItem task)
    {
        _context.Tasks.Remove(task);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TaskItem>> GetByProjectIdAsync(int projectId)
    {
        return await _context.Tasks
            .Where(t => t.ProjectId == projectId)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<IEnumerable<TaskItem>> GetByStatusAsync(TaskItemStatus status)
    {
        return await _context.Tasks
            .Where(t => t.Status == status)
            .AsNoTracking()
            .ToListAsync();
    }

}