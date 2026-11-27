using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using PackMan.Data;
using PackMan.Models;
using PackMan.Repositories;
using PackMan.Test.Data.Test;

namespace PackMan.Test.Data {
  public class DatabaseTest {

  
    //Order

    [Fact]
    public void AddOrderWithElementToDatabase() {

      //Arrange
      using var context = TestDatabase.CreateTestDatabase();                                //Lav en testdatabase og clear den.

      var orderRepository = new OrderRepository(context);
      var elementRepository = new ElementRepository(context);                               //Hent et repository så vi kan tilgå databasen

      var order = TestData.CreateOrder();                                                   //Databasen er clearet, så vi opretter ordren 
      var element = TestData.CreateElement(order);                                           //og et element til ordren og tilføjer den til databasen.

      //Act
      orderRepository.AddOrder(order);
      elementRepository.AddElement(element);

      // Assert
      var retrievedOrder = orderRepository.GetOrderById(order.TransportOrderId);            //Vi henter begge dele ned igen og asserter.
      var retrievedElement = elementRepository.GetElementById(element.ElementId);
      Assert.NotNull(retrievedOrder);
      Assert.Equal(order.TransportOrderId, retrievedOrder.TransportOrderId);
      Assert.Equal(order.RefOrderId, retrievedOrder.RefOrderId);
      Assert.NotNull(retrievedElement);
      Assert.Equal(element.ElementId, retrievedElement.ElementId);
      Assert.Single(retrievedOrder.Elements);
    }

    [Fact]
    public void UpdateOrderInDatabase() {
      //Arrange
      //Lav en testdatabase og clear den.
      using var context = TestDatabase.CreateTestDatabase();

      //Hent et repository så vi kan tilgå databasen
      var orderRepository = new OrderRepository(context);

      //Databasen er clearet, så vi opretter ordren og tilføjer den til databasen.
      var order = TestData.CreateOrder();
      orderRepository.AddOrder(order);

      //Vi henter ordren igen
      var retrivedOrder = orderRepository.GetOrderById(order.TransportOrderId);


      //Act
      //Vi opdaterer ordrens referencenummmer
      order.RefOrderId = 999;
      orderRepository.UpdateOrder(order);
      //Assert
      //Vi tjekker at ordren reelt er opdateret
      var retrievedOrder = orderRepository.GetOrderById(order.TransportOrderId);
      Assert.Equal(order.RefOrderId, retrievedOrder.RefOrderId);
    }

    //Delete Order
    [Fact]
    public void DeleteOrderInDatabase() {
      //Arrange
      using var context = TestDatabase.CreateTestDatabase();                          //Lav en testdatabase og clear den.

      var orderRepository = new OrderRepository(context);                             //Hent et repository så vi kan tilgå databasen

      var order = TestData.CreateOrder();                                             //Databasen er clearet, så vi opretter ordren og tilføjer den til databasen.
      orderRepository.AddOrder(order);

      var retrivedOrder = orderRepository.GetOrderById(order.TransportOrderId);       //Vi henter ordren igen

      //Act
      orderRepository.DeleteOrder(order.TransportOrderId);                            //Vi opdaterer ordrens referencenummmer

      //Assert
      var retrievedOrder = orderRepository.GetOrderById(order.TransportOrderId);     //Vi tjekker at ordren reelt er opdateret
      Assert.Null(retrievedOrder);
    }

    //PALLET TESTS

    [Fact]
    public void addPalletToDatabase() {
      //Arrange

      using var context = TestDatabase.CreateTestDatabase();

      var palletRepository = new PalletRepository(context);

      var pallet = TestData.CreatePallet();

      //Act
      palletRepository.AddPallet(pallet);

      // Assert
      var retrievedPallet = palletRepository.GetPalletById(pallet.Id);
      Assert.NotNull(retrievedPallet);
      Assert.Equal(pallet.Id, retrievedPallet.Id);
      Assert.Equal(pallet.Description, retrievedPallet.Description);
    }

    [Fact]
    public void updatePalletInDatabase() {
      //Arrange
      using var context = TestDatabase.CreateTestDatabase();

      var palletRepository = new PalletRepository(context);

      var pallet = TestData.CreatePallet();
      palletRepository.AddPallet(pallet);

      //Act

      pallet.Description = "Opdateret beskrivelse";
      palletRepository.UpdatePallet(pallet);

      //Assert
      var retrievedPallet = palletRepository.GetPalletById(pallet.Id);
      Assert.Equal(pallet.Description, retrievedPallet.Description);

    }

    [Fact]
    public void deletePalletFromDatabase() {
      //Arrange
      using var context = TestDatabase.CreateTestDatabase();

      var palletRepository = new PalletRepository(context);

      var pallet = TestData.CreatePallet();
      palletRepository.AddPallet(pallet);

      //Act
      palletRepository.DeletePallet(pallet.Id);

      //Assert
      var retrievedPallet = palletRepository.GetPalletById(pallet.Id);
      Assert.Null(retrievedPallet);
    }
  }
}
