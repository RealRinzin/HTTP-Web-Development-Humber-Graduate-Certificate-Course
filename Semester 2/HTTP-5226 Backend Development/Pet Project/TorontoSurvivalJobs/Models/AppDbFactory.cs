using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TorontoSurvivalJobs.Models;

public class AppDbFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(
"               Host=aws-1-ca-central-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.tlszlgullowkmpajbjwf;Password=?gn06d%JGL]i3H;SSL Mode=Require;Trust Server Certificate=true"
            );
        return new AppDbContext(optionsBuilder.Options);
    }
}