using Microsoft.EntityFrameworkCore;
using ToDoApi.Database;
using ToDoApi.Dtos;
using ToDoApi.Models;

namespace ToDoApi.IServices.Services;

public class TodoService : ITodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> TodoPost(Todo todo)
    {
        try
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return true;
        } 
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Todo?> TodoGetById(Guid id)
    {
        try
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            return todo;
        } 
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Todo>> TodoGetAll()
    {
        try
        {
            return await _context.Todos.ToListAsync();
        } 
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public async Task<bool> TodoUpdate(Guid id,TodoDto todo)
    {
        var oldTodo = await TodoGetById(id);
        if (oldTodo == null) return false;
        
        oldTodo.Title = todo.Title;
        oldTodo.Description = todo.Description;
        oldTodo.Completed = todo.Completed;
        
        try
        {
            _context.Todos.Update(oldTodo);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> TodoDelete(Guid id)
    {
        var todo = await TodoGetById(id);
        if (todo == null) return false;
        
        try
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}