using TorontoSurvivalJobs;

namespace TorontoSurvivalJobs.Models;

public class ViewModel
{
    public List<Job> Jobs { get; set; }
    public List<Company> Companies { get; set; }
    public List<Role> Roles { get; set; }
}