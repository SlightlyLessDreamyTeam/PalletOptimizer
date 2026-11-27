using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using PackMan.Data;
using PackMan.Models;
using PackMan.Repositories;

namespace PackMan.Test {
  public class UnitTest1 {

    [Fact]
    public void AddOrderWithElementToDatabase() {

      //Arrange
      var options = new DbContextOptionsBuilder<PackManDbContext>()
        .UseSqlServer("Server = localhost, 1444; Database = PackManDatabase.Test; User Id = sa; Password = YourStrong!Passw0rd; TrustServerCertificate = True; Encrypt = False")
        .Options;

      using var context = new PackManDbContext(options);

      context.Database.EnsureDeleted();
      context.Database.Migrate();

      var orderRepository = new OrderRepository(context);
      var elementRepository = new ElementRepository(context);

      Order order = new Order {
        RefOrderId = 543
      };

      Element element = new Element {
        Rotate = Element.RotateableEnum.yes,
        RequireSpecialPallet = false,
        Length = 10,
        Width = 20,
        Height = 30,
        Weight = 40,
        Series = "Serie A",
        Brand = "Velux",
        Order = order
      };

      //Act
      orderRepository.AddOrder(order);
      elementRepository.AddElement(element);

      // Assert
      var retrievedOrder = orderRepository.GetOrderById(order.TransportOrderId);
      var retrievedElement = elementRepository.GetElementById(element.ElementId);
      Assert.NotNull(retrievedOrder);
      Assert.Equal(order.TransportOrderId, retrievedOrder.TransportOrderId);
      Assert.Equal(order.RefOrderId, retrievedOrder.RefOrderId);
      Assert.NotNull(retrievedElement);
      Assert.Equal(element.ElementId, retrievedElement.ElementId);
      Assert.Single(retrievedOrder.Elements);
    }
    [Fact]
    public void addPalletToDatabase() {
      //Arrange
      var options = new DbContextOptionsBuilder<PackManDbContext>()
        .UseSqlServer("Server = localhost, 1444; Database = PackManDatabase.Test; User Id = sa; Password = YourStrong!Passw0rd; TrustServerCertificate = True; Encrypt = False")
        .Options;
      using var context = new PackManDbContext(options);
      context.Database.EnsureDeleted();
      context.Database.Migrate();

      var palletRepository = new PalletRepository(context);

      Pallet pallet = new Pallet {
        Description = "Standard Pallet",
        length = 120,
        width = 80,
        palletType = Pallet.PalletType.wood,
        Weight = 25,
        MaxWeight = 1000,
        Overhang = 0,
        AirBetweenElements = 10,
        isActive = true
      };
      //Act
      palletRepository.AddPallet(pallet);
      // Assert
      var retrievedPallet = palletRepository.GetPalletById(pallet.Id);
      Assert.NotNull(retrievedPallet);
      Assert.Equal(pallet.Id, retrievedPallet.Id);
      Assert.Equal(pallet.Description, retrievedPallet.Description);
    }

  }
  }
