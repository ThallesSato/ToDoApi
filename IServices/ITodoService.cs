using ToDoApi.Dtos;
using ToDoApi.Models;

namespace ToDoApi.IServices;

public interface ITodoService
{
    Task<bool> TodoPost(Todo todo);
    Task<Todo?> TodoGetById(Guid id);
    Task<List<Todo>> TodoGetAll();
    Task<bool> TodoUpdate(Guid id,TodoDto todo);
    Task<bool> TodoDelete(Guid id);
}