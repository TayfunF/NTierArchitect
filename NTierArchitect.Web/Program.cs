using Microsoft.EntityFrameworkCore;
using NTierArchitect.Core.Repositories;
using NTierArchitect.Core.UnitOfWorks;
using NTierArchitect.Repository;
using NTierArchitect.Repository.Repositories;
using NTierArchitect.Repository.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
