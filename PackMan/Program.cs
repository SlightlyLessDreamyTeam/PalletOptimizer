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

using (var scope = app.Services.CreateScope()) {
  var context = scope.ServiceProvider
      .GetRequiredService<PackManDbContext>();

  // TEST AF EF CORES MODEL
  var entities = context.Model.GetEntityTypes();

  foreach (var entity in entities) {
    System.Diagnostics.Debug.WriteLine(
        $"ENTITY: {entity.ClrType.Name}");

    foreach (var property in entity.GetProperties()) {
      System.Diagnostics.Debug.WriteLine(
          $"PROPERTY: {property.Name}");
    }
  }

  // Din eksisterende SQL-forbindelsestest
  bool canConnect = context.Database.CanConnect();
}

using (var scope = app.Services.CreateScope()) {
  var context = scope.ServiceProvider
      .GetRequiredService<PackManDbContext>();

  try {
    bool canConnect = context.Database.CanConnect();

    System.Diagnostics.Debug.WriteLine(canConnect
        ? "Forbindelse til SQL Server OK!"
        : "Kunne ikke oprette forbindelse.");
  }
  catch (Exception ex) {
    System.Diagnostics.Debug.WriteLine($"Fejl: {ex.Message}");
  }
}

System.Diagnostics.Debug.WriteLine("MIN TEST VIRKER!");

app.Run();
