using TorontoSurvivalJobs.Models;
namespace TorontoSurvivalJobs.Services;

public class UserService
{

    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }
    // Get All users
    public List<User> getAllUsers()
    {
        return _context.Users.ToList();
    }
    // Get Individual Users

    public User getUser(int id)
    {
        return _context.Users.Find(id);
    }
    // Add New User
    public void CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    // Delete the job
    public void DeleteUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return;
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
    //update client
    public void UpdateUser(User user)
    {
        _context.Update(user);
        _context.SaveChanges();
    }
}