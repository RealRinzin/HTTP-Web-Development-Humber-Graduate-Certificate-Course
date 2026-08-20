using Microsoft.EntityFrameworkCore;
using TorontoSurvivalJobs.Data;
using TorontoSurvivalJobs.Models;
namespace TorontoSurvivalJobs.Services
{
    public class JobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Job>> GetAllJobs()
        {
            return await _context.Jobs
                .Include(j => j.Category)
                .Include(j => j.Company)
                .Include(j => j.Location)
                .ToListAsync();
        }
        public async Task<Job?> GetJobById(int id)
        {
            return await _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.Category)
                .Include(j => j.Location)
                .FirstOrDefaultAsync(j => j.JobId == id);
        }

        public async Task CreateJob(Job job)
        {
            job.DateScraped = DateTime.UtcNow;

            _context.Jobs.Add(job);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateJob(Job job)
        {
            _context.Jobs.Update(job);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job != null)
            {
                _context.Jobs.Remove(job);

                await _context.SaveChangesAsync();
            }
        }

        // Duplicate Check
        public async Task<bool> JobExists(
            string title,
            int companyId)
        {
            return await _context.Jobs
                .AnyAsync(j =>
                    j.Title.ToLower() == title.ToLower() &&
                    j.CompanyId == companyId);
        }
        // SEARCH
        public async Task<List<Job>> SearchJobs(
    string? query,
    string? location)
        {
            var jobs = _context.Jobs
                .Include(j => j.Company)
                .Include(j => j.Category)
                .Include(j => j.Location)
                .AsQueryable();

            // WHAT
            if (!string.IsNullOrWhiteSpace(query))
            {
                query = query.Trim();

                jobs = jobs.Where(j =>
                    j.Title.Contains(query) ||
                    (j.Description != null &&
                     j.Description.Contains(query)));
            }

            // WHERE
            if (!string.IsNullOrWhiteSpace(location))
            {
                location = location.Trim();

                jobs = jobs.Where(j =>
                    j.Location != null &&
                    j.Location.Name.Contains(location));
            }

            return await jobs
                .OrderByDescending(j => j.SurvivalScore)
                .ToListAsync();
        }
    }
}