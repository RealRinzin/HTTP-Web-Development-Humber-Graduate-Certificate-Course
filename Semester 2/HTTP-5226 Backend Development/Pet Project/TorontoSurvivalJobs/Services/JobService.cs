using TorontoSurvivalJobs.Models;
namespace TorontoSurvivalJobs.Services;

public class JobService
{
    private readonly AppDbContext _context;

    public JobService(AppDbContext context)
    {
        _context = context;
    }

    // List all the Jobs
    public List<Job> getAllJobs()
    {
        return _context.Jobs.ToList();
    }
    // Get the Individual Job Details
    public Job getJob(int id)
    {
        return _context.Jobs.Find(id);
    }

    // Add New jobs
    public void CreateJob(Job job)
    {
        _context.Jobs.Add(job);
        _context.SaveChanges();
    }
    // Delete the job
    public void DeleteJob(int id)
    {
        var job = _context.Jobs.Find(id);
        if (job == null) return;
        _context.Jobs.Remove(job);
        _context.SaveChanges();
    }
    // Update Client
    //update client
    public void UpdateClient(Job job)
    {
        _context.Update(job);
        _context.SaveChanges();
    }
}