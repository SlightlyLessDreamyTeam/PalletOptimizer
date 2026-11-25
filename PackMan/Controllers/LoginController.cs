using Microsoft.AspNetCore.Mvc;

namespace PackMan.Controllers;

public class LoginController : Controller {

  public IActionResult Login() {
    return View();
  }
}
