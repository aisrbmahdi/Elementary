using TodoList.Models;

namespace TodoList.Services
{
    public interface ITodoService
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task CreateAsync(ToDoItem item);
        Task<ToDoItem> UpdateAsync(int id, string name, bool isCompleted);
        Task<bool> DeleteAsync(int id);
        Task<ToDoItem> GetByIdAsync(int id);
    }
}