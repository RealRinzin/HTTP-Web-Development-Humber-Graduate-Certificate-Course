//Builder reads configs, environmental settings before we build the app
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); //allows the MVC pattern, Razor Views + routing between them
//TO DO include the API




//builds the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //Global error handler
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); //HTTP Strict Transport Security /Forces browsers to use HTTPS instead of HTTP/ Improves security
}

//Redirect HTTP to HTTPS
//If a user visits using http://, they are automatically redirected to https://.
app.UseHttpsRedirection();

//Allows ASP.NET to match URLs to controllers and actions
// / Home / About 
// Controller: HomeController
// Action: About
app.UseRouting();

//Checks if a user has permission to access something... we will use it later
app.UseAuthorization();

//Serves static files: CSS, JavaScript, Images
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
