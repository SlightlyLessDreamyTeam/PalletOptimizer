//using PackMan.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

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
