using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PackMan.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackMan.Test.Data.Test {
  internal class TestDatabase {
    public static PackManDbContext CreateTestDatabase() {
      var options = new DbContextOptionsBuilder<PackManDbContext>()
        .UseSqlServer("Server = localhost, 1444; Database = PackManDatabase.Test; User Id = sa; Password = YourStrong!Passw0rd; TrustServerCertificate = True; Encrypt = False")
        .Options;
      var context = new PackManDbContext(options);

      context.Database.EnsureDeleted();
      context.Database.Migrate();

      return context;
    }
  
}
}
