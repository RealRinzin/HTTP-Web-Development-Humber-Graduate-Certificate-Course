using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;
using TorontoSurvivalJobs.Services;

namespace TorontoSurvivalJobs.Controllers
{
    public class DashboardController : Controller
    {
        private readonly JobService _jobService;
        private readonly CategoryService _categoryService;
        private readonly CompanyService _companyService;
        public DashboardController(
            JobService jobService,
            CategoryService categoryService,
            CompanyService companyService)
        {
            _jobService = jobService;
            _categoryService = categoryService;
            _companyService = companyService;
        }

        // Jobs
        public async Task<IActionResult> Jobs()
        {
            var jobs = await _jobService.GetAllJobs();
            return View("~/Views/Dashboard/Jobs/Index.cshtml",jobs);
        }
    }

}