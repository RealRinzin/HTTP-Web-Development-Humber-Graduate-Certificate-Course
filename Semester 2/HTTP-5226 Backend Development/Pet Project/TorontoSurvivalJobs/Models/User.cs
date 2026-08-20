using System.ComponentModel.DataAnnotations;

namespace TorontoSurvivalJobs;

public class User
{
    public int id { get; set; } // Primary Key
    [Required]
    [DataType(DataType.Text)]
    public string name { get; set; } = ""; // Name of the Role
    [Required]
    [DataType(DataType.Text)]
    public string username { get; set; } = ""; // Name of the Role
    [Required]
    [DataType(DataType.Text)]
    public string role { get; set; } = ""; // Name of the Role

    public string password { get; set; } = ""; // Description of the job
}