using System.ComponentModel.DataAnnotations;

namespace TorontoSurvivalJobs.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ICollection<Job> Jobs { get; set; }
            = new List<Job>();
    }
}