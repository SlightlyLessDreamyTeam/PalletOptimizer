using Microsoft.AspNetCore.Mvc;

namespace PackMan.Controllers;

public class PackingGuideController : Controller {

  public IActionResult PackingGuide() {
    return View();
  }
}
