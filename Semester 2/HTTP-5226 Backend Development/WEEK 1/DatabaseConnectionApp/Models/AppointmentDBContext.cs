using Microsoft.EntityFrameworkCore;

namespace DatabaseConnectionApp.Models
{
    public class AppointmentDBContext : DbContext
    {

        // Constructor
        public AppointmentDBContext(DbContextOptions<AppointmentDBContext> options) : base(options)
        {
            
        }
        
        // Creating a table for the appointment list 
        public DbSet<Client> clientList { get; set; } // creating a table for the client list 
    }
}