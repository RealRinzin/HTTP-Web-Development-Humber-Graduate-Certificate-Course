using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace tvShowPetProject.Controllers;
using tvShowPetProject.Models;
using tvShowPetProject.Services;

public class ActorController : Controller
{

    public ActorEndPointService service{get; set;}
    // Constructor
    public ActorController(ActorEndPointService service_)
    {
        service = service_;
    }
    public  async Task<IActionResult> Index()
    {
        var content = await service.getData();

        return View(content);
    }
}
