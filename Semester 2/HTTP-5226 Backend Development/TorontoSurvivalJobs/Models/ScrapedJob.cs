namespace TorontoSurvivalJobs.Models
{
    public class ScrapedJob
    {
        public string Title { get; set; } = string.Empty;

        public int CompanyId { get; set; }


        public int LocationId { get; set; }

        public string? Url { get; set; }
        public decimal? SalaryMin { get; set; }

        public decimal? SalaryMax { get; set; }

        public string? JobType { get; set; }

        public string? Description { get; set; }
    }
}