// Models/AppointmentViewModel.cs
using BookingApp.Models;

namespace BookingApp.Models;

public class AppointmentViewModel
{
    public Appointment Appointment { get; set; } = new Appointment();
    public List<Client> Clients { get; set; } = new List<Client>();
    public List<Service> Services { get; set; } = new List<Service>();
}