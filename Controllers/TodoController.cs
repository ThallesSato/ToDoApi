using Microsoft.AspNetCore.Mvc;
using ToDoApi.Dtos;
using ToDoApi.IServices;
using ToDoApi.Models;

namespace ToDoApi.Controllers;

[ApiController]
[Route("api/tasks")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)

    {
        _todoService = todoService;
    }

    [HttpPost]
    public async Task<ActionResult> TodoPost(TodoDto todoDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        Todo todo = new Todo()
        {
            Completed = todoDto.Completed,
            Description = todoDto.Description,
            Title = todoDto.Title
        };
        
        try
        {
            await _todoService.TodoPost(todo);
            return CreatedAtAction( nameof(TodoGetById), new { todo.Id }, todo);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> TodoGetById(Guid id)
    {
        try
        {
            var todo = await _todoService.TodoGetById(id);
            if (todo == null) return NotFound();
            return Ok(todo);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Todo>>> TodoGetAll()
    {
        try
        {
            return Ok(await _todoService.TodoGetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> TodoUpdate(Guid id, TodoDto todoDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try
        {
            var response = await _todoService.TodoUpdate(id, todoDto);
            if (!response) return NotFound();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> TodoDelete(Guid id)
    {
        try
        {
            var response = await _todoService.TodoDelete(id);
            if (!response) return NotFound();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}