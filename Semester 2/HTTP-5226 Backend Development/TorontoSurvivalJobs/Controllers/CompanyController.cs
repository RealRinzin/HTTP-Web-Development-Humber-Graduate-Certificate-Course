using Microsoft.AspNetCore.Mvc;
using TorontoSurvivalJobs.Models;
using TorontoSurvivalJobs.Services;

namespace TorontoSurvivalJobs.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly CompanyService _companyService;

        public CompaniesController(CompanyService companyService)
        {
            _companyService = companyService;
        }
        //  INDEX

        public async Task<IActionResult> Index()
        {
            var companies = await _companyService.GetAllCompanies();

            return View(companies);
        }
        // SHOW
        public async Task<IActionResult> Details(int id)
        {
            var company = await _companyService.GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }
        // CREATE
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }

            await _companyService.CreateCompany(company);

            return RedirectToAction(nameof(Index));
        }
        // EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyService.GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(company);
            }

            await _companyService.UpdateCompany(company);

            return RedirectToAction(nameof(Index));
        }
        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _companyService.GetCompanyById(id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _companyService.DeleteCompany(id);

            if (!deleted)
            {
                TempData["ErrorMessage"] =
                    "This company cannot be deleted because it has jobs assigned to it.";

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}