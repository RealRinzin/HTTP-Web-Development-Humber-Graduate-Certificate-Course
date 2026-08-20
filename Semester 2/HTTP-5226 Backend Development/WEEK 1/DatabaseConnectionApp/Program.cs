using DatabaseConnectionApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using DatabaseConnectionApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connection string
// builder.Services.AddDbContext<AppointmentDBContext>(
// Local Database Connection
// Options => Options.UseMySql(
//     "server=localhost;port=8889;database=appointmentManager;user=root;password=root;",
//     ServerVersion.AutoDetect("server=localhost;port=8889;database=appointmentManager;user=root;password=root;"
//     ))
// );
builder.Services.AddDbContext<AppointmentDBContext>(options =>

options.UseNpgsql(
// builder.Configuration.GetConnectionString("Host=aws-1-ca-central-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.wsnduxbbnrieoxmjcscu;Password=?gn06d%JGL]i3H; SSL Mode = Require; Trust Server Certificate = true"),
builder.Configuration.GetConnectionString("DefaultConnection"),
o =>
{
    o.CommandTimeout(60);
    o.EnableRetryOnFailure(
    maxRetryCount: 5,
    maxRetryDelay: TimeSpan.FromSeconds(10),
    errorCodesToAdd: null
    );
}
)
);
builder.Services.AddScoped<AppointmentService>();
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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
