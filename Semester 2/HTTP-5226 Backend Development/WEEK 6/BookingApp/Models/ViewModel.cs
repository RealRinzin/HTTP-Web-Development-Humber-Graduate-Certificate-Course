using BookingApp;

namespace BookingApp.Models;

public class ViewModel
{
    public List<Client> Clients { get; set; }
    public List<Service> Services { get; set; }
    public List<Appointment> Appointments { get; set; }
}