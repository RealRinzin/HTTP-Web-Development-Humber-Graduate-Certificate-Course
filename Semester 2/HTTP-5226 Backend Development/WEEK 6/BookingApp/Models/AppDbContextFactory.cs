using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookingApp.Models;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(
                // "Host=aws-1-ca-central-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.wdfumtellnjbolukqtii;Password=?gn06d%JGL]i3H;SSL Mode=Require;Trust Server Certificate=true"
                "Host=aws-1-ca-central-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.ynxjiygofbbgjcimbnft;Password=?gn06d%JGL]i3H;SSL Mode=Require;Trust Server Certificate=true"
            );
        return new AppDbContext(optionsBuilder.Options);
    }
}