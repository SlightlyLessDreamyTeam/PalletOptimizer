using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PackMan.Data;
using PackMan.Models;
namespace PackMan.Controllers;

public class PalletController : Controller {
  private readonly PackManDbContext _context;

  public PalletController(PackManDbContext context) {

    _context = context;
  }

  public IActionResult Pallet() {
    IEnumerable<Pallet> pallets = _context.Pallets.ToList();
    return View(pallets);
  }
  /*
  [HttpGet]
  public IActionResult Edit(int id) {
    Pallet pallet = _context.GetById(id);

    if (pallet is null) {
      return NotFound();

    }
  }
  [HttpPost]
  public IActionResult Edit(int id, Pallet model) {
    if (!ModelState.IsValid)
      return View(model);

    if (pallet is null) {
      return NotFound();

    }
  }
  */
}
