using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Models;

namespace BookingApp.Controllers;

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
            Clients = _context.Clients.ToList(),
            Services = _context.Services.ToList(),
            Appointments = _context.Appointments.ToList(),
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
