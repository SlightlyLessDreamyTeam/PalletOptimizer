using PackMan.Data;
using PackMan.Models;

namespace PackMan.Repositories {
  public class OrderRepository : IOrderRepository {

    private readonly PackManDbContext _context;

    public OrderRepository(PackManDbContext context) {
      _context = context;
    }

    public Order? GetOrderById(int id) {
      return _context.Orders.FirstOrDefault(o => o.TransportOrderId == id);
    }

    public void AddOrder(Order order) {
      _context.Orders.Add(order);
      _context.SaveChanges();
    }

    public void UpdateOrder(Order order) {
      _context.Orders.Update(order);
      _context.SaveChanges();
    }

    public void DeleteOrder(int id) {
      var order = GetOrderById(id);
      if (order != null) {
        _context.Orders.Remove(order);
        _context.SaveChanges();
      }
    }

    
  }
}
