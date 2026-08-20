using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;
using TorontoSurvivalJobs.Services;

namespace TorontoSurvivalJobs.Controllers;

public class HomeController : Controller
{
    private readonly JobService _jobService;
    private readonly CategoryService _categoryService;
    private readonly CompanyService _companyService;
    private readonly LocationService _locationService;

    public HomeController(
        JobService jobService,
        CategoryService categoryService,
        CompanyService companyService,
        LocationService locationService
        )
    {
        _jobService = jobService;
        _categoryService = categoryService;
        _companyService = companyService;
        _locationService = locationService;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.Jobs = await _jobService.GetAllJobs();
        ViewBag.Categories = await _categoryService.GetAllCategories();
        ViewBag.Companies = await _companyService.GetAllCompanies();
        ViewBag.Locations = await _locationService.GetAllLocations();
        return View();
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
