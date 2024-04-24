using Microsoft.AspNetCore.Hosting.Server;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebAppRazorPages.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
       sqlServerOptionsAction: sqlOptions =>
       {
           sqlOptions.EnableRetryOnFailure(
           maxRetryCount: 5,
           maxRetryDelay: TimeSpan.FromSeconds(15),
           errorNumbersToAdd: null);
       });

options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IMotorcycle, SqlMotorcycleRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Account/Login");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.MapControllers();

app.Run();
