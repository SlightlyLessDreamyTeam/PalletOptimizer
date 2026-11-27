using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PackMan.Models;
using PackMan.ViewModels;

namespace PackMan.Controllers;

public class LoginController : Controller {

  private readonly SignInManager<AppUser> _signInManager;

  public LoginController(SignInManager<AppUser> signInManager) {
    _signInManager = signInManager;
  }

  [HttpGet]
  public IActionResult Login() {
    return View(new LoginViewModel());
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginViewModel model) {
    if (!ModelState.IsValid) {
      return View(model);
    }

    var result = await _signInManager.PasswordSignInAsync(
      model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

    if (result.Succeeded) {
      return RedirectToAction("Orders", "Orders");
    }

    ModelState.AddModelError(string.Empty, "Forkert e-mail eller adgangskode");
    return View(model);
  }

  [HttpPost]
  public async Task<IActionResult> Logout() {
    await _signInManager.SignOutAsync();
    return RedirectToAction("Login", "Login");
  }
}
