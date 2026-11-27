//using PackMan.Repositories;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PackMan.Data;
using PackMan.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PackManDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
  options.Password.RequiredLength = 8;
  options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<PackManDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
  options.LoginPath = "/Login/Login";
  options.AccessDeniedPath = "/Login/Login";
});

//builder.Services.AddSingleton<IRepository, Repository>();

var app = builder.Build();



app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}")
  .WithStaticAssets();


app.Run();
