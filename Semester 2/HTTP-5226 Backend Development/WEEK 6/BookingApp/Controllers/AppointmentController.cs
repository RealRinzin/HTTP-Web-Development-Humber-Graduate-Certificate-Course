using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookingApp.Models;
using BookingApp.Services;

namespace BookingApp.Controllers;

public class AppointmentController : Controller
{
    private readonly AppointmentService _appointmentService;
    private readonly ClientService __clientService;
    private readonly ServiceService __serviceService;

    public AppointmentController(
        AppointmentService appointmentService,
        ClientService clientService,
        ServiceService serviceService)
    {
        _appointmentService = appointmentService;
        __clientService = clientService;
        __serviceService = serviceService;
    }

    public IActionResult Index()
    {
        var appointments = _appointmentService.GetAppointments();
        return View(appointments);
    }

    public IActionResult Add()
    {
        var vm = new AppointmentViewModel
        {
            Clients = __clientService.GetClients() ?? new List<Client>(),
            Services = __serviceService.GetServices() ?? new List<Service>()
        };
        return View(vm);
    }

    [HttpPost]
    public IActionResult AddNew(AppointmentViewModel model)
    {
        // 1. Validate the appointment model
        var validationError = _appointmentService.ValidateAppointment(model.Appointment);
        if (validationError != null)
        {
            ModelState.AddModelError("", validationError);
        }

        // 2. If invalid, re-populate lists and return view
        if (!ModelState.IsValid)
        {
            model.Clients = __clientService.GetClients() ?? new List<Client>();
            model.Services = __serviceService.GetServices() ?? new List<Service>();
            return View("Add", model);
        }

        // 3. Save appointment
        _appointmentService.AddAppointment(model.Appointment);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var appointment = _appointmentService.getTheAppointment(id);
        if (appointment == null)
        {
            return NotFound();
        }

        PopulateDropdowns();
        return View(appointment);
    }

    [HttpPost]
    public IActionResult Update(Appointment appointment)
    {
        var validationError = _appointmentService.ValidateAppointment(appointment);
        if (validationError != null)
        {
            ModelState.AddModelError("", validationError);
        }

        if (!ModelState.IsValid)
        {
            PopulateDropdowns();
            return View("Edit", appointment);
        }

        _appointmentService.UpdateAppointment(appointment);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _appointmentService.DeleteAppointment(id);
        return RedirectToAction("Index");
    }

    private void PopulateDropdowns()
    {
        var clients = __clientService.GetClients() ?? new List<Client>();
        var services = __serviceService.GetServices() ?? new List<Service>();

        ViewBag.Clients = new SelectList(clients, "Id", "name");
        ViewBag.Services = new SelectList(services, "Id", "name");
    }
}