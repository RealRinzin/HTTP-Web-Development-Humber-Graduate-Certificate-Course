using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;

namespace TorontoSurvivalJobs.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {

        var model = new ViewModel
        {
            Jobs = _context.Jobs.ToList(),
        };
        return View(model);

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
