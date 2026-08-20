using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiniBlogRoleBase.Models;
using MiniBlogRoleBase.Services;

namespace MiniBlogRoleBase.Controllers;

public class HomeController : Controller
{
    private readonly PostService _postService;
    public HomeController(PostService postService)
    {
        _postService = postService;
    }

    public IActionResult Index()
    {
        var posts = _postService.GetPosts();
        return View(posts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
