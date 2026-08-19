using Microsoft.AspNetCore.Mvc;

namespace Sem12026.Controllers
{
    public class IntroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestPage()
        {
            return View();
        }
    }
}
