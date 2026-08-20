using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Services;
using TorontoSurvivalJobs.Models;
namespace TorontoSurvivalJobs.Controllers
{
    public class ScraperController : Controller
    {
        private readonly JobScraperService _jobScraperService;
        private readonly CompanyService _companyService;
        private readonly JobService _jobService;
        private readonly LocationService _locationService;

        public ScraperController(
            JobScraperService jobScraperService,
            CompanyService companyService,
            JobService jobService,
            LocationService locationService
            )
        {
            _jobScraperService = jobScraperService;
            _companyService = companyService;
            _jobService = jobService;
            _locationService = locationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Scrape()
        {
            var url = "https://cms.iamrinzin.dev/tims.html";

            using var httpClient = new HttpClient();

            try
            {
                var html = await httpClient.GetStringAsync(url);
                var jobs = _jobScraperService.ScrapeJobs(html);

                return View("Results", jobs);
            }
            catch (HttpRequestException)
            {
                return NotFound("Failed to retrieve sample jobs from the remote URL.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save()
        {
            var url = "https://cms.iamrinzin.dev/tims.html";

            using var httpClient = new HttpClient();

            string html;
            try
            {
                html = await httpClient.GetStringAsync(url);
            }
            catch (HttpRequestException)
            {
                return NotFound("Failed to retrieve sample jobs from the remote URL.");
            }

            var scrapedJobs = _jobScraperService.ScrapeJobs(html);
            int newJobs = 0;
            int existingJobs = 0;

            foreach (var scrapedJob in scrapedJobs)
            {
                var company = await _companyService.GetOrCreateCompany(scrapedJob.CompanyId);

                var exists = await _jobService.JobExists(
                    scrapedJob.Title,
                    company.CompanyId);

                if (exists)
                {
                    existingJobs++;
                    continue;
                }

                var job = new Job
                {
                    Title = scrapedJob.Title,
                    CompanyId = company.CompanyId,
                    LocationId = 1,
                    SalaryMin = scrapedJob.SalaryMin,
                    SalaryMax = scrapedJob.SalaryMax,
                    JobType = scrapedJob.JobType,
                    PostalCode = "PostalCode",
                    Description = scrapedJob.Description,
                    Source = "Sample Toronto Jobs",
                    DateScraped = DateTime.Now
                };

                await _jobService.CreateJob(job);
                newJobs++;
            }

            TempData["ScrapeMessage"] = $"{newJobs} new job(s) saved. {existingJobs} job(s) already existed.";
            return Redirect("/jobs");
            // return RedirectToAction(nameof(Index));
        }

    }
}