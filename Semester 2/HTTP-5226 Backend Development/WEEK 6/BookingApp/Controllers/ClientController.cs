using Microsoft.AspNetCore.Mvc;
using BookingApp.Models;
using BookingApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace BookingApp.Controllers;

public class ClientController : Controller
{
    private readonly ClientService __clientService;
    // inject the service
    public ClientController(ClientService clientService)
    {
        __clientService = clientService;
    }
    // In the index page return the list of all the clients
    public IActionResult Index()
    {
        var clients = __clientService.GetClients();
        return View(clients);
        // return View();
    }
    // Add View
    public IActionResult Add()
    {
        return View();
    }

    // HTTP Actions
    [HttpPost]
    public IActionResult AddNew(Client client)
    {
        // Check if all the fields are filled
        if (!ModelState.IsValid)
        {
            return View("Add");
        }
        // If successed then, create the record and redirect to inedex
        __clientService.AddClient(client);
        return RedirectToAction("index");
    }
    // Edit the Client
    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Check if all the fields are filled
        var client = __clientService.getTheClient(id);
        if (client == null)
        {
            return NotFound();
        }

        return View(client);
    }
    // Update the Client 
    [HttpPost]
    public IActionResult Update(Client client)
    {
        if (!ModelState.IsValid)
        {
            return View("Edit");
        }
        __clientService.UpdateClient(client);
        return RedirectToAction("Index");
    }

    // Delete the client
    public IActionResult Delete(int id)
    {
        __clientService.DeleteClient(id);
        return RedirectToAction("Index");
    }


}