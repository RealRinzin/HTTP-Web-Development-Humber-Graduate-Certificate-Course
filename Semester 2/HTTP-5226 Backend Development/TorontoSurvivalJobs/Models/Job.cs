using System.ComponentModel.DataAnnotations;

namespace TorontoSurvivalJobs.Models
{
    public class Job
    {
        public int JobId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]

        public string? PostalCode { get; set; }

        public string? Description { get; set; }

        public decimal? SalaryMin { get; set; }

        public decimal? SalaryMax { get; set; }

        public string? JobType { get; set; }

        public string? ExperienceLevel { get; set; }

        public DateOnly? DatePosted { get; set; }

        public DateTime DateScraped { get; set; }

        public string? Url { get; set; }

        public string? Source { get; set; }

        public int SurvivalScore { get; set; }

        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public int CompanyId { get; set; }

        public Company? Company { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }

    }
}