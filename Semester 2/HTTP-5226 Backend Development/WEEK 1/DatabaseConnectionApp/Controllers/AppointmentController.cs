using DatabaseConnectionApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseConnectionApp.Controllers
{
    public class AppointmentController : Controller
    {
        public AppointmentService _service;
        public AppointmentController(AppointmentService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.getClients());
        }

        // Add Client View
        public IActionResult AddClient()
        {
            return View();
        }
    }
}