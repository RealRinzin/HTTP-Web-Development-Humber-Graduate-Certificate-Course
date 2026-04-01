using ApiConnection.Services;
using Microsoft.AspNetCore.Mvc;
namespace ApiConnection.Controllers;

public class RapidApiController : Controller
{
    public RapidApiService service { get; set; }
    public RapidApiController(RapidApiService service_)
    {
        service = service_;
    }

    public async Task<IActionResult> ListJobs()
    {
        var content = await service.getData();
        Console.WriteLine(content);
        return View(content);

    }
}

