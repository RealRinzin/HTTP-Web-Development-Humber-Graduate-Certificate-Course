using Microsoft.EntityFrameworkCore;

namespace DatabaseConnectionApp.Models
{
    public class AppointmentDBContext : DbContext
    {

        // Constructor
        public AppointmentDBContext(DbContextOptions<AppointmentDBContext> options) : base(options)
        {
            // 
        }

        public DbSet<Client> clientList { get; set; } // creating a table for the client list 
    }
}