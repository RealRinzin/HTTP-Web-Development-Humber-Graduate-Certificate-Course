using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniReddit.Data;
using MiniReddit.Models;

namespace MiniReddit.Controllers
{
    [Authorize] // must be logged in for every action in this controller
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // POST /Comments/Create
        [HttpPost]
        public async Task<IActionResult> Create(int postId, string text)
        {
            var me = await _userManager.GetUserAsync(User);
            if (me == null || me.IsBanned) return Forbid();

            _db.Comments.Add(new Comment { PostId = postId, AuthorId = me.Id, Text = text });
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Post");
        }

        // POST /Comments/Edit
        // A user can only edit their OWN comment. Admins can also edit any comment
        // (per the assignment: "An admin can make and edit a comment").
        [HttpPost]
        public async Task<IActionResult> Edit(int commentId, string newText)
        {
            var comment = await _db.Comments.FindAsync(commentId);
            if (comment == null) return NotFound();

            var me = await _userManager.GetUserAsync(User);
            bool isOwner = comment.AuthorId == me!.Id;
            bool isAdmin = User.IsInRole("Admin");

            if (!isOwner && !isAdmin) return Forbid();

            comment.Text = newText;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Post");
        }

        // POST /Comments/Delete
        // Only Admins can delete OTHER people's comments (rubric requirement).
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int commentId)
        {
            var comment = await _db.Comments.FindAsync(commentId);
            if (comment == null) return NotFound();

            _db.Comments.Remove(comment);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Post");
        }

        // POST /Comments/Like   -- the chosen bonus feature (20%)
        [HttpPost]
        public async Task<IActionResult> Like(int commentId)
        {
            var comment = await _db.Comments.FindAsync(commentId);
            if (comment == null) return NotFound();

            comment.Likes += 1;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Post");
        }
    }
}
