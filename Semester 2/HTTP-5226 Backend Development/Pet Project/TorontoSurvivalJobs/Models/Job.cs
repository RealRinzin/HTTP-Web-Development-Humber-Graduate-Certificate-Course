using System.ComponentModel.DataAnnotations;

namespace TorontoSurvivalJobs;

public class Job
{
    public int id { get; set; }
    [Required]
    [DataType(DataType.Text)]
    // Foreign key relations with the Company
    public string role {get;set;} = "";
    [Required]

    public string company {get;set;} = "";
    public string logo {get;set;} = "";
    public string location {set;get;} = "";
    [Required]

    public string type {set;get;} = "";
    public string posted { get; set; } = ""; // Description of the job
    [Required]

    public string description { get; set; } = ""; // Description of the job
    [Required]
    [DataType(DataType.Url)]
    public string apply { get; set; } = ""; // website address of the company
    // public int CompanyId { get; set; }
    // public Company Company { get; set; }    // Navigation Property
    // public Role Role { get; set; }          // Navigation Property
    // // Foreign key relations with the Role

    // public int RoleId { get; set; }         // Foreign Key




}