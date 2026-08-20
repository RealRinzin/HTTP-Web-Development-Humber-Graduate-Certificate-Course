using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DatabaseConnectionApp.Models
{
    public class SchoolDbContextFactory : IDesignTimeDbContextFactory<AppointmentDBContext>
    {
        public AppointmentDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppointmentDBContext>
            ();
            // optionsBuilder.UseNpgsql("Host=aws-1-ca-central-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.wsnduxbbnrieoxmjcscu;Password=?gn06d%JGL]i3H; SSL Mode = Require; Trust Server Certificate = true");
            optionsBuilder.UseNpgsql("Host=aws-1-us-east-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.bctxodptcbxilirggcpe;Password=?gn06d%JGL]i3H; SSL Mode = Require; Trust Server Certificate = true");
            return new AppointmentDBContext(optionsBuilder.Options);
        }
    }
}
