//using PackMan.Repositories;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PackMan.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PackManDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddSingleton<IRepository, Repository>();

var app = builder.Build();

app.UseRouting();

app.UseStaticFiles();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}")
  .WithStaticAssets();

app.Run();
