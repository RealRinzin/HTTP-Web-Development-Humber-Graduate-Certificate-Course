using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniReddit.Models;

namespace MiniReddit.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        // POST /Admin/Ban
        [HttpPost]
        public async Task<IActionResult> Ban(string userId)
        {
            var target = await _userManager.FindByIdAsync(userId);
            if (target == null) return NotFound();

            target.IsBanned = true;
            await _userManager.UpdateAsync(target);
            return RedirectToAction("Index", "Post");
        }
    }
}
