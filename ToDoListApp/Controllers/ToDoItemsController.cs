using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;
using ToDoListApp.Services;

namespace ToDoListApp.Controllers
{
    public class ToDoItemsController(IToDoListService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await service.GetItemsAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItem = await service.GetItemByIdAsync(id.Value);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,IsCompleted")] ToDoItem toDoItem)
        {
            if (!ModelState.IsValid) return View(toDoItem);

            await service.AddItemsAsync(toDoItem);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItem = await service.GetItemByIdAsync(id.Value);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,IsCompleted")] ToDoItem toDoItem)
        {
            if (id != toDoItem.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(toDoItem);

            try
            {
                await service.UpdateItemAsync(toDoItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await service.ExistsAsync(toDoItem.Id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDoItem = await service.GetItemByIdAsync(id.Value);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDoItem = await service.GetItemByIdAsync(id);

            if (toDoItem != null)
            {
                await service.DeleteItemAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AboutCreator()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
