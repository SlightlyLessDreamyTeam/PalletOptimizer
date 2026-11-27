using PackMan.Models;

namespace PackMan.Repositories {
  public interface IOrderRepository {

    Order? GetOrderById(int id);
    void AddOrder(Order order);
    void UpdateOrder(Order order);
    void DeleteOrder(int id);
  }
}
