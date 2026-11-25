using Microsoft.AspNetCore.Mvc;

namespace PackMan.Controllers;

public class PalletController : Controller {

  public IActionResult Pallet() {
    return View();
  }
}
