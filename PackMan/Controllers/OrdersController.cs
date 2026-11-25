using Microsoft.AspNetCore.Mvc;

namespace PackMan.Controllers;

public class OrdersController : Controller {

  public IActionResult Orders() {
    return View();
  }
}
