using System.ComponentModel.DataAnnotations;

namespace TorontoSurvivalJobs.Models
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;

        public string? Location { get; set; }

        public string? Website { get; set; }

        public ICollection<Job> Jobs { get; set; }
            = new List<Job>();
    }
}