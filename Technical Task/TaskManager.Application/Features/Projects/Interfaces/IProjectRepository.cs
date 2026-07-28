using TaskManager.Domain.Entities;

namespace TaskManager.Application.Features.Projects.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync();

    Task<Project?> GetByIdAsync(int id);

    Task AddAsync(Project project);

    void Update(Project project);

    void Delete(Project project);

    Task SaveChangesAsync();
}