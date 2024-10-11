using EmployeeWeb.ExternalServices.Contracts;
using EmployeeWeb.ExternalServices.Impl;
using EmployeeWeb.Services.Contracts;
using EmployeeWeb.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeExternalService, EmployeeExternalService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddHttpClient<IEmployeeExternalService, EmployeeExternalService>(client =>
{
    client.BaseAddress = new Uri("http://hub.dummyapis.com/employee");
})
.ConfigurePrimaryHttpMessageHandler(() =>
    new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
