using TaskManager.Domain.Enums;

namespace TaskManager.Application.Features.Tasks.DTOs;

public class TaskDto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public TaskItemStatus Status { get; set; }

    public int ProjectId { get; set; }
}