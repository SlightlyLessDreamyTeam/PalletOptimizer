using Microsoft.AspNetCore.Mvc;

namespace PackMan.Controllers;

public class ImportController : Controller {
  // private readonly IRepository _repository;
  //
  // public ImportController(IRepository repository) {
  //   _repository = repository;
  // }

  public IActionResult Import() {
    return View();
  }

  [HttpPost]
  public IActionResult Import(IFormFile file) {
    if (file is null || file.Length == 0) {
      // TODO: create IsXML(file) helper method and add !IsXML(file) to guard clause
      ViewData["ErrorMessage"] = "Vælg en XML-fil, for at importere indholdet";
      return View();
    }

    using (Stream stream = file.OpenReadStream())
      // _repository.Save(file.FileName, stream);

      ViewData["Message"] = $"Ordrer fra filen '{file.FileName}' er blevet tilføjet.";
    return RedirectToAction("Orders", "Orders");
  }
}
