using BookingApp.Models;

namespace BookingApp.Services;

public class ServiceService
{
    private readonly AppDbContext _context;
    public ServiceService(AppDbContext context)
    {
        _context = context;
    }
    // return all services
    public List<Service> GetServices()
    {
        return _context.Services.ToList();
    }

    // Add New Client
    public void AddService(Service service)
    {
        _context.Services.Add(service);
        _context.SaveChanges();
    }

    //view client
    public Service getTheService(int id)
    {

        return _context.Services.Find(id);
    }


    // Update the existing Client
    public void UpdateService(Service service)
    {
        _context.Update(service);
        _context.SaveChanges();
    }

    // Delete the Client 
    public void DeleteService(int id)
    {
        var service = _context.Services.Find(id);
        if (service == null) return;
        _context.Services.Remove(service);
        _context.SaveChanges();
    }
}