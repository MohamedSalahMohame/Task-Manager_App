using AutoMapper;
using TaskManager.Application.Features.Projects.DTOs;
using TaskManager.Application.Features.Tasks.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Project
        CreateMap<Project, ProjectDto>();

        CreateMap<CreateProjectDto, Project>();

        CreateMap<UpdateProjectDto, Project>();

        // Task
        CreateMap<TaskItem, TaskDto>();

        CreateMap<CreateTaskDto, TaskItem>();

        CreateMap<UpdateTaskDto, TaskItem>();
    }
}