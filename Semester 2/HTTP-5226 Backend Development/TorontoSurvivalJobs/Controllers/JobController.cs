using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;
using TorontoSurvivalJobs.Services;

namespace TorontoSurvivalJobs.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobService _jobService;
        private readonly CategoryService _categoryService;
        private readonly CompanyService _companyService;
        public JobsController(
            JobService jobService,
            CategoryService categoryService,
            CompanyService companyService)
        {
            _jobService = jobService;
            _categoryService = categoryService;
            _companyService = companyService;
        }
        // INDEX
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetAllJobs();

            return View(jobs);
        }
        // SHOW
        public async Task<IActionResult> Details(int id)
        {
            var job = await _jobService.GetJobById(id);
            ViewBag.Jobs = await _jobService.GetAllJobs();


            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }
        // CREATE
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategories();

            var companies = await _companyService.GetAllCompanies();

            ViewBag.Categories = categories;
            ViewBag.Companies = companies;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Job job)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories =
                    await _categoryService.GetAllCategories();

                ViewBag.Companies =
                    await _companyService.GetAllCompanies();

                return View(job);
            }

            await _jobService.CreateJob(job);

            return RedirectToAction(nameof(Index));
        }
        //  EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var job = await _jobService.GetJobById(id);

            if (job == null)
            {
                return NotFound();
            }

            ViewBag.Categories =
                await _categoryService.GetAllCategories();

            ViewBag.Companies =
                await _companyService.GetAllCompanies();

            return View(job);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Categories =
                    await _categoryService.GetAllCategories();

                ViewBag.Companies =
                    await _companyService.GetAllCompanies();

                return View(job);
            }

            await _jobService.UpdateJob(job);

            return RedirectToAction(nameof(Index));
        }
        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var job = await _jobService.GetJobById(id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _jobService.DeleteJob(id);

            return RedirectToAction(nameof(Index));
        }
        //  SEARCH
        [HttpGet]
        public async Task<IActionResult> Search(
            string? query,
            string? location)
        {
            var jobs = await _jobService.SearchJobs(
                query,
                location);

            ViewBag.Query = query;
            ViewBag.Location = location;

            return View(jobs);
        }
    }
}