using DatabaseConnectionApp.Models;
namespace DatabaseConnectionApp.Services;

public class AppointmentService
{
    public AppointmentDBContext context;
    public AppointmentService(AppointmentDBContext _context)
    {
        context = _context;
    }
    public List<Client> getClients()
    {
        return context.clientList.ToList();
    }
}  

