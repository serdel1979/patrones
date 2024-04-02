
using DesignPatterns.Respository;
using Microsoft.EntityFrameworkCore;
using Patterns.UnitOW.Entities;
using UnitOffWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PatternsContext>(op =>
{
    op.UseNpgsql(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IUnitOffWork, UnitOffWork.UnitOffWork>();

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
