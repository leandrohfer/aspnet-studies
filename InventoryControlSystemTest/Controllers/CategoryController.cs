using InventoryControlSystemTest.Data;
using InventoryControlSystemTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InventoryControlSystemTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly InventoryControlSystemTestContext _context;

        public CategoryController(InventoryControlSystemTestContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.OrderBy(c => c.Name)
                .AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Insert(int? id)
        {
            if (id.HasValue)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
            return View(new CategoryModel());
        }

        private bool CategoryExist(int id)
        {
            return _context.Categories.Any(cat => cat.IdCategory == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(int? id, [FromForm] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    if (CategoryExist(id.Value))
                    {
                        _context.Categories.Update(category);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["message"] = MessageModel.Serialize("Category successfully changed!");
                        }
                        else
                        {
                            TempData["message"] = MessageModel.Serialize("Error changing category!", TypeMessage.Error);
                        }
                    }
                    else
                    {
                        TempData["message"] = MessageModel.Serialize("Category not found!", TypeMessage.Error);
                    }
                }
                else
                {
                    _context.Categories.Add(category);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["message"] = MessageModel.Serialize("Category successfully changed!");
                    }
                    else
                    {
                        TempData["message"] = MessageModel.Serialize("Error changing category!", TypeMessage.Error);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(category);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id.HasValue)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category != null)
                {
                    return View(category);
                }
                else
                {
                    TempData["message"] = MessageModel.Serialize("Category not found.", TypeMessage.Error);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                TempData["message"] = MessageModel.Serialize("There is no category selected for deletion.", TypeMessage.Error);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                if (await _context.SaveChangesAsync() > 0)
                {
                    TempData["message"] = MessageModel.Serialize("Category deleted successfully!");
                }
                else
                {
                    TempData["message"] = MessageModel.Serialize("Error deleting category!", TypeMessage.Error);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["message"] = MessageModel.Serialize("Category not found!", TypeMessage.Error);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
