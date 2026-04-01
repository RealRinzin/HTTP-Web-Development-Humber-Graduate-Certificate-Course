using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tvShowPetProject.Models;
using tvShowPetProject.Services;

namespace tvShowPetProject.Controllers;

public class TVShowController : Controller
{
    public ApiEndPointService service { get; set; }
    public TVShowController(ApiEndPointService service_)
    {
        service = service_;
    }

    public async Task<IActionResult> Index()
    {
        var content = await service.getData();
        // foreach (var item in content) 
            // {
            //     Console.WriteLine(item.Show.name);
            // }
            // Console.WriteLine(content);
            return View(content);
        // return View();

    }


    // public IActionResult Index()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}