using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;
using TorontoSurvivalJobs.Services;

namespace TorontoSurvivalJobs.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // INDEX
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategories();

            return View(categories);
        }
        // SHOW
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        // CREATE
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _categoryService.CreateCategory(category);

            return RedirectToAction(nameof(Index));
        }
        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            await _categoryService.UpdateCategory(category);

            return RedirectToAction(nameof(Index));
        }
        //  DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _categoryService.DeleteCategory(id);

            if (!deleted)
            {
                TempData["ErrorMessage"] =
                    "This category cannot be deleted because it has jobs assigned to it.";

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}