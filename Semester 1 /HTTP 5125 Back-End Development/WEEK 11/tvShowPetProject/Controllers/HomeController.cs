using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tvShowPetProject.Models;
using tvShowPetProject.Services;


namespace tvShowPetProject.Controllers;

public class HomeController : Controller
{
     public ApiEndPointService service { get; set; }
    public HomeController(ApiEndPointService service_)
    {
        service = service_;
    }

    public async Task<IActionResult> Index()
    {
        var content = await service.getData();
        return View(content);
    }
    // Deta
    public async Task<IActionResult> Detail(int id)
    {
        var show = await service.GetShowById(id);

        if (show == null)
        {
            return NotFound(); // good practice
        }

        return View(show);
    }

    public async Task<IActionResult> Search(string keyword)
    {

        Console.WriteLine(keyword);
        var shows = await service.getData();

        if (!string.IsNullOrEmpty(keyword))
        {
            shows = shows
                .Where(s => s.name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        return View(shows);
    }
    // public IActionResult Index()
    // {
    //     return View();
    // }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
