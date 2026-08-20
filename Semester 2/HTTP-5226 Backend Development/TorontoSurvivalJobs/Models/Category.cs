using System.ComponentModel.DataAnnotations;

namespace TorontoSurvivalJobs.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Job> Jobs { get; set; }
            = new List<Job>();
    }
}