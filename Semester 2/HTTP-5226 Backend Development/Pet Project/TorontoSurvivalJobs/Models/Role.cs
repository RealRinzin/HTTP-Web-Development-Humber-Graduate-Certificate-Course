using System.ComponentModel.DataAnnotations;

namespace TorontoSurvivalJobs;

public class Role
{
    public int id { get; set; } // Primary Key
    [Required]
    [DataType(DataType.Text)]

    public string name { get; set; } = ""; // Name of the Role
    [Required]
    [DataType(DataType.Text)]
    public string description { get; set; } = ""; // Description of the job
}