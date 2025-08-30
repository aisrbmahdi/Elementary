
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

using TodoList.Data;
using TodoList.Models;

namespace TodoList.Services
{
    public class TodoService(TodoDbContext context) : ITodoService
    {
        public async Task CreateAsync(ToDoItem item)
        {
            context.ToDoItems.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {

            var todo = await context.ToDoItems.FindAsync(id);
            if (todo == null)
            {
                return false;
            }

            context.ToDoItems.Remove(todo);
            await context.SaveChangesAsync();
            return true;

        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            var todo = await context.ToDoItems.FindAsync(id);
            return todo;
        }       

        public async Task<ToDoItem> UpdateAsync(int id, string name, bool isCompleted)
        {
            var existingTodo = await context.ToDoItems.FindAsync(id);
            if (existingTodo == null)
            {
                throw new KeyNotFoundException($"Todo item with ID {id} not found.");
            }

            existingTodo.Name = name;
            existingTodo.IsCompleted = isCompleted;

            await context.SaveChangesAsync();
            return existingTodo;
        }

    }
}