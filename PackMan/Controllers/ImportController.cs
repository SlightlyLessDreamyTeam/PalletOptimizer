using Microsoft.AspNetCore.Mvc;

namespace PackMan.Controllers;

public class ImportController : Controller {

  public IActionResult Import() {
    return View();
  }
}
