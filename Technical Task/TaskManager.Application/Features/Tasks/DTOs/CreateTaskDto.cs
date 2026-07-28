using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Enums;

namespace TaskManager.Application.Features.Tasks.DTOs;

public class CreateTaskDto
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    [Required]
    public TaskItemStatus Status { get; set; }

    [Required]
    public int ProjectId { get; set; }
}