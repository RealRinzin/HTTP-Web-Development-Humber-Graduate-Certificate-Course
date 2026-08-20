namespace BookingApp.Models;

public class Appointment
{
    public int Id { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public int ServiceId { get; set; }
    public Service? Service { get; set; }
    public int Duration { get; set; }
public DateTime Date { get; set; }           // Keep for UI (Date only)
    public TimeSpan Time { get; set; }           // Keep for UI

    // New: Store as proper UTC DateTime
    public DateTime StartDateTime { get; set; }

    public DateTime UpdatedAt { get; set; }
}