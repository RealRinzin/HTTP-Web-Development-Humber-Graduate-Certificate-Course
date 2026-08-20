using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Assignment_2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment_2.Controllers;

public class HomeController : Controller
{

    // EVERYONE can view this page (Guests, Users, Admins)
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }
    [Authorize]
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
