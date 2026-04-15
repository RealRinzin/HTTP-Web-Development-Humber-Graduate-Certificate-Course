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
        return View(content);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var show = await service.GetShowById(id);

        if (show == null)
        {
            return NotFound(); // good practice
        }

        return View(show);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}