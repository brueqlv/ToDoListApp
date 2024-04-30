using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public class ToDoListService(ToDoDbContext context) : IToDoListService
    {
        public async Task AddItemsAsync(ToDoItem item)
        {
            context.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await GetItemByIdAsync(id);

            if (item != null)
            {
                context
                    .Set<ToDoItem>()
                    .Remove(item);

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

        public async Task UpdateItemAsync(ToDoItem item)
        {
            context
                .Set<ToDoItem>()
                .Update(item);

            await context.SaveChangesAsync();
        }
    }
}
