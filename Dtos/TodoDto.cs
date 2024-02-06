using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Dtos;

public class TodoDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public bool Completed { get; set; }
}