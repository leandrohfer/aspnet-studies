using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryControlSystemTest.Data;
using InventoryControlSystemTest.Models;

namespace InventoryControlSystemTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly InventoryControlSystemTestContext _context;

        public ProductController(InventoryControlSystemTestContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.OrderBy(c => c.Name).Include(p => p.Category)
                .AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Insert(int? id)
        {
            var categories = _context.Categories.OrderBy(x => x.Name).AsNoTracking().ToList();
            var categoriesSelectList = new SelectList(categories, nameof(CategoryModel.IdCategory), nameof(CategoryModel.Name));

            ViewBag.Categories = categoriesSelectList;

            if (id.HasValue)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            return View(new ProductModel());
        }

        private bool ProductExist(int id)
        {
            return _context.Products.Any(cat => cat.IdProduct == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(int? id, [FromForm] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue)
                {
                    if (ProductExist(id.Value))
                    {
                        _context.Products.Update(product);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["message"] = MessageModel.Serialize("Product successfully changed!");
                        }
                        else
                        {
                            TempData["message"] = MessageModel.Serialize("Error changing product!", TypeMessage.Error);
                        }
                    }
                    else
                    {
                        TempData["message"] = MessageModel.Serialize("Product not found!", TypeMessage.Error);
                    }
                }
                else
                {
                    _context.Products.Add(product);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["message"] = MessageModel.Serialize("Product registered successfully!");
                    }
                    else
                    {
                        TempData["message"] = MessageModel.Serialize("Error when registering product!", TypeMessage.Error);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id.HasValue)
            {
                var product = await _context.Products.FindAsync(id);
                var category = _context.Categories.FindAsync(product.IdCategoria);
                ViewBag.category = category;
                if (product != null)
                {
                    return View(product);
                }
                else
                {
                    TempData["message"] = MessageModel.Serialize("Product not found.", TypeMessage.Error);
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                TempData["message"] = MessageModel.Serialize("There is no product selected for deletion.", TypeMessage.Error);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                if (await _context.SaveChangesAsync() > 0)
                {
                    TempData["message"] = MessageModel.Serialize("Product deleted successfully!");
                }
                else
                {
                    TempData["message"] = MessageModel.Serialize("Error deleting product!", TypeMessage.Error);
                }
            }
            else
            {
                TempData["message"] = MessageModel.Serialize("Product not found!", TypeMessage.Error);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
