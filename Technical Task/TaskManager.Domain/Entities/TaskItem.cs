using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    public TaskItemStatus Status { get; set; } = TaskItemStatus.ToDo;
    public DateTime? DueDate { get; set; }

    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;
}