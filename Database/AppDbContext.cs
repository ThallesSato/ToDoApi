using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>  options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set;}
}