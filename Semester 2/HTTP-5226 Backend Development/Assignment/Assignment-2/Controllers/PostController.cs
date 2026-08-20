using Assignment_2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class PostController
{
    private readonly PostService _posts;
    public PostController(PostService posts) => _posts = posts;

    public async Task<IActionResult> Index() => View(await _posts.GetAllAsync());

    public async Task<IActionResult> Details(int id)
    {
        var post = await _posts.GetByIdAsync(id);
        return post is null ? NotFound() : View(post);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(string title, string body)
    {
        await _posts.CreateAsync(title, body, ViewBag.CurrentUserId);
        return RedirectToAction(nameof(Index));
    }
}