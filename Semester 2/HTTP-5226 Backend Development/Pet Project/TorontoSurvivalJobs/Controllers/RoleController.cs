using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;

namespace TorontoSurvivalJobs.Controllers;

public class RoleController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
