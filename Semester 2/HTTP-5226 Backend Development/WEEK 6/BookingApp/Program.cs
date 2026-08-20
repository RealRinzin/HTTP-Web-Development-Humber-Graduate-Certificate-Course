using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookingApp.Models;
using BookingApp.Services;
using Microsoft.Extensions.Options;
using BookingApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString,
        o =>
        {
            o.CommandTimeout(60); // Set the command timeout to 60 seconds
            o.EnableRetryOnFailure(
                maxRetryCount: 5,// Set the maximum number of retry attempts
                maxRetryDelay: TimeSpan.FromSeconds(30), // Set the maximum delay between retry attempts
                errorCodesToAdd: null
            );
        }));
// register the client service
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<AppointmentService>();
// Microsoft Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();
var app = builder.Build();
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
app.Run();
