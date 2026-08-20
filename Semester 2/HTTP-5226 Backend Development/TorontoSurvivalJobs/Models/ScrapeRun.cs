using System.ComponentModel.DataAnnotations;

namespace TorontoSurvivalJobs.Models
{
    public class ScrapeRun
    {
        public int ScrapeRunId { get; set; }

        [Required]
        public string Source { get; set; } = string.Empty;

        public DateTime StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public int JobsFound { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}