using BookingApp.Models;
namespace BookingApp.Services;

public class ClientService
{
    private readonly AppDbContext _context;
    public ClientService(AppDbContext context)
    {
        _context = context;
    }

    // Get the client list
    public List<Client> GetClients()
    {
        return _context.Clients.ToList();
    }
    // Add New Client
    public void AddClient(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }
    // Get the Individual Client for Edit
    //view client
    public Client getTheClient(int id)
    {

        return _context.Clients.Find(id);
    }

    // Update the existing Client
    public void UpdateClient(Client client)
    {
        _context.Update(client);
        _context.SaveChanges();
    }
    // Delete the Client 
    public void DeleteClient(int id)
    {
        var client = _context.Clients.Find(id);
        if (client == null) return;
        _context.Clients.Remove(client);
        _context.SaveChanges();
    }


}