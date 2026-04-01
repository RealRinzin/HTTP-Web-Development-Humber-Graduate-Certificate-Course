using Microsoft.AspNetCore.Mvc;
namespace ASPnetApp.Controllers;

public class IntroController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
