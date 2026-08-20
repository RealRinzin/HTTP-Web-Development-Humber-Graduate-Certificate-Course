using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;

namespace TorontoSurvivalJobs.Controllers;

public class CompanyController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
