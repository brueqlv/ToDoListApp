using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public interface IToDoListService
    {
        public Task AddItemsAsync(ToDoItem item);
        Task DeleteItemAsync(int id);
        Task<IEnumerable<ToDoItem>> GetItemsAsync();
        Task<ToDoItem?> GetItemByIdAsync(int id);
        Task UpdateItemAsync(ToDoItem item);
        Task<bool> ExistsAsync(int? id);
    }
}
