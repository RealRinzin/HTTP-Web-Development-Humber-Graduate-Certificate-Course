using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniBlogRoleBase.Data;
using MiniBlogRoleBase.Models;
using MiniBlogRoleBase.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// 1. PostgreSQL / Supabase DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(connectionString, o =>
    {
        o.CommandTimeout(60);
        o.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorCodesToAdd: null
        );
    }));


// register the client service
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<CommentService>();
// Microsoft Identity
// Microsoft Identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<AppDBContext>()
.AddDefaultTokenProviders()
// CRUCIAL CHANGE: Explicitly pass your custom user type to the default UI engine
.AddDefaultUI(); 

// Also ensure global Razor Page services are explicitly registered in your container
builder.Services.AddRazorPages();

// Run at last
var app = builder.Build();
// 3. Migrate and Seed Database

// 3. Migrate and Seed Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<AppDBContext>();

        Console.WriteLine("--> Testing database migration execution...");
        await dbContext.Database.MigrateAsync();
        Console.WriteLine("--> Migration phase checked successfully.");

        Console.WriteLine("--> Launching DbSeeder.SeedAsync...");
        await DbSeeder.SeedAsync(services);
        Console.WriteLine("--> DbSeeder.SeedAsync executed to completion!");
    }
    catch (Exception ex)
    {
        // FORCE THE APPLICATION TO CRASH AND PRINT THE REASON TO THE TERMINAL WINDOW
        Console.WriteLine("=================================================");
        Console.WriteLine($"!!! CRITICAL SEEDING FAULT: {ex.Message}");
        if (ex.InnerException != null)
        {
            Console.WriteLine($"!!! INNER DETAIL: {ex.InnerException.Message}");
        }
        Console.WriteLine("=================================================");

        // This stops execution so you can read the error before the server closes down
        throw;
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
// for the user identity authentication

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
// Add this line to map the Identity login routes
app.MapRazorPages();

app.Run();
