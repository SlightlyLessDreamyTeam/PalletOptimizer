using System.ComponentModel.DataAnnotations;


namespace PackMan.Models;
  public class PalletFormViewModel {

    public int Id { get; set; }

    [Required(ErrorMessage = "Er påkrævet.")]
    public Pallet.PalletType palletType {  get; set; }

    [Required(ErrorMessage = "Er påkrævet.")]
    public int length { get; set; }

    [Required(ErrorMessage = "Er påkrævet.")]
    public int width { get; set; }

    [Required(ErrorMessage = "Er påkrævet.")]
    public int Weight { get; set; }

    [Required(ErrorMessage = "Er påkrævet.")]
    public int MaxWeight { get; set; }

    [Required(ErrorMessage = "Er påkrævet")]
    public int Overhang {  get; set; }

    [Required(ErrorMessage = "Er påkrævet.")]
    public bool isActive { get; set; }

    [StringLength(300, ErrorMessage = "Beskrivelse må max. indholde 300 tegn")]
    public string Description { get; set; } = string.Empty;

  }

