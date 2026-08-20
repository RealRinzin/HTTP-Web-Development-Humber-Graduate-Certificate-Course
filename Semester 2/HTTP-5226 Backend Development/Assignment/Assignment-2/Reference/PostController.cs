using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniReddit.Data;

namespace MiniReddit.Controllers
{
    // No [Authorize] here on purpose: Guests must be able to view the page.
    // Individual actions (comment/edit/delete/ban) enforce their own roles.
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PostController(ApplicationDbContext db) => _db = db;

        // GET /Post  (or /Post/Index)
        public async Task<IActionResult> Index()
        {
            var post = await _db.Posts
                .Include(p => p.Comments)
                    .ThenInclude(c => c.Author)
                .OrderBy(p => p.Id)
                .FirstOrDefaultAsync();

            return View(post); // Views/Post/Index.cshtml
        }
    }
}
