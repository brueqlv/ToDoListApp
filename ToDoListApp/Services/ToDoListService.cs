using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public class ToDoListService(ToDoDbContext context) : IToDoListService
    {
        public async Task AddItemsAsync(ToDoItem toDoItem)
        {
            context.Add(toDoItem);
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var toDoItem = await GetItemByIdAsync(id);

            if (toDoItem != null)
            {
                context
                    .Set<ToDoItem>()
                    .Remove(toDoItem);

                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int? id)
        {
            return await context
                .Set<ToDoItem>()
                .AnyAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task<ToDoItem?> GetItemByIdAsync(int id)
        {
            return await context
                .Set<ToDoItem>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task<IEnumerable<ToDoItem>> GetItemsAsync()
        {
            return await context
                .Set<ToDoItem>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateItemAsync(ToDoItem toDoItem)
        {
            context
                .Set<ToDoItem>()
                .Update(toDoItem);

            await context.SaveChangesAsync();
        }
    }
}
