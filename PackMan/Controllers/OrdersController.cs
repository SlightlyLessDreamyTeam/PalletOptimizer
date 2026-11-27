using Microsoft.AspNetCore.Mvc;
using PackMan.Models;

namespace PackMan.Controllers;

public class OrdersController : Controller {

  public IActionResult Orders() {
    return View(GetOrders());
  }

  public List<Order> GetOrders() {
    // Retrieve orders from the database or any other data source
    List<Order> orders = new List<Order>
    {
        new Order { TransportOrderId = 1, RefOrderId = 1 },
        new Order { TransportOrderId = 2, RefOrderId = 2 },
        new Order { TransportOrderId = 3, RefOrderId = 3 }
    };
    return orders;
  }
}
