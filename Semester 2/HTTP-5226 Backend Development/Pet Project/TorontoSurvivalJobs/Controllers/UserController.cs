using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;
using TorontoSurvivalJobs.Services;

namespace TorontoSurvivalJobs.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    public IActionResult Index()
    {
        var users = _userService.getAllUsers();
        return View(users);
    }

    // Add View
    public IActionResult Add()
    {
        return View();
    }

    // Edit View
    public IActionResult Edit()
    {
        return View();
    }

    // HTTP METHODS
    [HttpGet]
    public async Task<IActionResult> Detail(int id)
    {
        var user = _userService.getUser(id);
        if (user == null) return NotFound();
        return View(user);
    }
    [HttpPost]
    public IActionResult Create(User user)
    {
        _userService.CreateUser(user);
        return RedirectToAction("index");
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        _userService.DeleteUser(id);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var user = _userService.getUser(id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }
    // POST JOB
    [HttpPost]
    public IActionResult Edit(User user)
    {
        _userService.UpdateUser(user);
        return RedirectToAction("Index");
    }

}
