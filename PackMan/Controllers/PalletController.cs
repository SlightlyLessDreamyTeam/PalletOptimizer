using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PackMan.Data;
using PackMan.Models;
using PackMan.Repositories;
using static PackMan.Models.Pallet;
namespace PackMan.Controllers;

public class PalletController : Controller {
  private readonly IPalletRepository _palletRepo;

  public PalletController(IPalletRepository palletRepo) {

    _palletRepo = palletRepo;
  }

  public IActionResult Pallet() {
    IEnumerable<Pallet> pallets = _palletRepo.GetAllPallets();
    return View(pallets);
  }
  
  [HttpGet]
  public IActionResult Edit(int id) {
    Pallet pallet = _palletRepo.GetPalletById(id);

    if (pallet is null) {
      return NotFound();
    }
    //mapping kan måske undgåes flere steder ved at implementere samme "Copy" metode som Flemse?
    PalletFormViewModel model = new PalletFormViewModel {
      Id = pallet.Id,
      palletType = pallet.palletType,
      length = pallet.length,
      width = pallet.width,
      Weight = pallet.Weight,
      Overhang = pallet.Overhang,
      isActive = pallet.isActive,
      Description = pallet.Description
    };
      return View(model);
  }

  [HttpPost]
  public IActionResult Edit(PalletFormViewModel model) {
    if (!ModelState.IsValid)
      return View(model);

    Pallet pallet = _palletRepo.GetPalletById(model.Id);

    if (model is null) {
      return NotFound();
    }
    //Igen måske Flemses Copy metode?
    pallet.palletType = model.palletType;
    pallet.length = model.length;
    pallet.width = model.width;
    pallet.Weight = model.Weight;
    pallet.Overhang = model.Overhang;
    pallet.isActive = model.isActive;
    pallet.Description = model.Description;

      _palletRepo.UpdatePallet(pallet);

    return RedirectToAction(nameof(Pallet));
  }
  
}
