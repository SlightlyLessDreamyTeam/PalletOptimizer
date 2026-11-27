using Microsoft.AspNetCore.Mvc;
using PackMan.Models;
using PackMan.Data;

namespace PackMan.Controllers;

public class PalletController : Controller {
  private readonly PackManDbContext _context;
  public PalletController (PackManDbContext context) {
    _context = context;
  }

  public IActionResult Pallet() {
    IEnumerable<Pallet> pallets = _context.Pallets.ToList();
    return View(pallets);
  }
}
