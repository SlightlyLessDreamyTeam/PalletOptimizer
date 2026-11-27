using System.ComponentModel.DataAnnotations;

namespace PackMan.ViewModels;

public class LoginViewModel {

  [Required(ErrorMessage = "Venligst indtast din e-mail")]
  [EmailAddress(ErrorMessage = "Ugyldig e-mail")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "Venligst indtast din adgangskode")]
  [DataType(DataType.Password)]
  public string Password { get; set; } = string.Empty;

  [Display(Name = "Husk mig")]
  public bool RememberMe { get; set; }
}
