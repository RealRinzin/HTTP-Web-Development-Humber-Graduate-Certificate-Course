using Microsoft.EntityFrameworkCore;
using TorontoSurvivalJobs.Data;
using TorontoSurvivalJobs.Models;
namespace TorontoSurvivalJobs.Services
{
    public class LocationService
    {
        private readonly ApplicationDbContext _context;

        public LocationService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Locations
            .OrderBy(c => c.Name)
            .ToListAsync();
        }
    }
}