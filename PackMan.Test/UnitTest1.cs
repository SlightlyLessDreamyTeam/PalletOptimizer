using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using PackMan.Data;
using PackMan.Models;
using PackMan.Repositories;

namespace PackMan.Test {
  public class UnitTest1 {
    
    [Fact]
    public void Test1() {
      public PackManDbContext _context;
    public OrderRepository _orderRepository = new OrderRepository(_context);

    Order order = new Order {
      TransportOrderId = 2,
      RefOrderId = 543
    };

       _orderRepository.AddOrder(order);
      // Assert that the order was added successfully
      var _retrievedOrder = _orderRepository.GetOrderById(order.TransportOrderId);
       Assert.NotNull(_retrievedOrder);
      Assert.Equal(order.TransportOrderId, _retrievedOrder.TransportOrderId);
      Assert.Equal(order.RefOrderId, _retrievedOrder.RefOrderId);
      } 

  }
  }
