using System.ComponentModel.DataAnnotations;

namespace BookingApp;

public class Service
{

    public int Id { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string name { get; set; } = "";
    [Required]
    [DataType(DataType.Currency)]
    public decimal price { get; set; }
    [Required]

    public double Duration { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string? description { get; set; }
}
