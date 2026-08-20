using System.ComponentModel.DataAnnotations;

namespace BookingApp;

public class Client
{
    public int Id { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string name { get; set; } = "";
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? email { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string? phone { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string? address { get; set; }
}
