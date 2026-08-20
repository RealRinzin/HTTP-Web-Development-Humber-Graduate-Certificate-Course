using System.ComponentModel.DataAnnotations;

namespace TorontoSurvivalJobs;

public class Company
{
    public int id { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string name { get; set; } = "";
    [Required]
    [DataType(DataType.Url)]
    public string logo { get; set; } = "";

    [Required]
    [DataType(DataType.Url)]
    public string website { get; set; } = "";
    [Required]
    [DataType(DataType.Text)]
    public string description { get; set; } = "";
}