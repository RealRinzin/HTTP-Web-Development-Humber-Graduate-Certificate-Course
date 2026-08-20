using Microsoft.AspNetCore.Mvc;
using BookingApp.Models;
using BookingApp.Services;

namespace BookingApp.Controllers;

public class ServiceController : Controller
{

    private readonly ServiceService _serviceService;
    // inject the service
    public ServiceController(ServiceService serviceService)
    {
        _serviceService = serviceService;
    }


    // In the index page return the list of all the clients
    public IActionResult Index()
    {
        var services = _serviceService.GetServices();
        return View(services);
    }

    // Add View

    public IActionResult Add()
    {
        return View();
    }

    // HTTP Actions
    [HttpPost]
    public IActionResult AddNew(Service service)
    {
        // Check if all the fields are filled
        if (!ModelState.IsValid)
        {
            return View("Add");
        }
        // If successed then, create the record and redirect to inedex
        _serviceService.AddService(service);
        return RedirectToAction("index");
    }

    // Edit the Client
    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Check if all the fields are filled
        var service = _serviceService.getTheService(id);
        if (service == null)
        {
            return NotFound();
        }

        return View(service);
    }

    // Update the Client 
    [HttpPost]
    public IActionResult Update(Service service)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit");
        }
        _serviceService.UpdateService(service);
        return RedirectToAction("Index");
    }


    // Delete the client
    public IActionResult Delete(int id)
    {
        _serviceService.DeleteService(id);
        return RedirectToAction("Index");
    }
}