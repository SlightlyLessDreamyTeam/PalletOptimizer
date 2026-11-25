using Microsoft.AspNetCore.Mvc;

namespace PackMan.Controllers;

public class SettingsController : Controller {

  public IActionResult Settings() {
    return View();
  }
}
