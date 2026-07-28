using System.ComponentModel.DataAnnotations;

namespace TaskManager.Application.Features.Projects.DTOs;

public class UpdateProjectDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }
}