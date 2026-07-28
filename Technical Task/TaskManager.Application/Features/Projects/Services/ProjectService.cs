using TaskManager.Application.Features.Projects.DTOs;
using TaskManager.Application.Features.Projects.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Features.Projects.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<ProjectDto>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllAsync();

        return projects.Select(project => new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt
        });
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if (project is null)
            return null;

        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt
        };
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
    {
        var project = new Project
        {
            Name = dto.Name,
            Description = dto.Description
        };

        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();

        return new ProjectDto
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            CreatedAt = project.CreatedAt
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateProjectDto dto)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if (project is null)
            return false;

        project.Name = dto.Name;
        project.Description = dto.Description;

        _projectRepository.Update(project);
        await _projectRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if (project is null)
            return false;

        _projectRepository.Delete(project);
        await _projectRepository.SaveChangesAsync();

        return true;
    }
}