using LivApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivApi.Data
{
    class TodoItemsContext : DbContext
    {
    public TodoItemsContext(DbContextOptions<TodoItemsContext> options)
        : base(options) { }

    public DbSet<Todo> Todos => Set<Todo>();
    }
}