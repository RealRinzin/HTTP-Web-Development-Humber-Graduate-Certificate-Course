using Microsoft.EntityFrameworkCore;
using TorontoSurvivalJobs.Data;
using TorontoSurvivalJobs.Models;

namespace TorontoSurvivalJobs.Services
{
    public class CompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await _context.Companies
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
        public async Task<Company?> GetCompanyById(int id)
        {
            return await _context.Companies
                .Include(c => c.Jobs)
                .FirstOrDefaultAsync(c => c.CompanyId == id);
        }

        public async Task CreateCompany(Company company)
        {
            _context.Companies.Add(company);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompany(Company company)
        {
            _context.Companies.Update(company);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCompany(int id)
        {
            var company = await _context.Companies
                .Include(c => c.Jobs)
                .FirstOrDefaultAsync(c => c.CompanyId == id);

            if (company == null)
            {
                return false;
            }

            if (company.Jobs.Any())
            {
                return false;
            }

            _context.Companies.Remove(company);

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Company?> GetCompanyByID(int id)
        {
            return await _context.Companies
                .FirstOrDefaultAsync(c => c.CompanyId == id);
        }
        public async Task<Company> GetOrCreateCompany(int id)
        {
            var company = await GetCompanyByID(id);

            if (company != null)
            {
                return company;
            }

            company = new Company
            {
                CompanyId = id
            };

            await CreateCompany(company);

            return company;
        }
    }
}