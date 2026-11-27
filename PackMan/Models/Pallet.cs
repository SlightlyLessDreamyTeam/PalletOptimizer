using System.Collections;

namespace PackMan.Models;

public class Pallet {
  public int Id { get; set; }
  public string Description { get; set; } = string.Empty;
  public int length { get; set; }
  public int width { get; set; }
  public enum PalletType { wood, euro, alu }
  public PalletType palletType { get; set; }
  public int Weight { get; set; }
  public int MaxWeight { get; set; }
  public int Overhang { get; set; }
  public int AirBetweenElements { get; set; }
  public bool isActive { get; set; }
}
