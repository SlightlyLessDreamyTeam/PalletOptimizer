namespace PackMan.Models;

public class Element {

  public int ElementId { get; set; }

  public RotateableEnum Rotate { get; set; }

  public bool RequireSpecialPallet {
    get; set;
  } = false;
  public int Length { get; set; }

  public int Width { get; set; }

  public int Height { get; set; }

  public int Weight { get; set; }

  public string Series { get; set; } = String.Empty;

  public string Brand { get; set; } = String.Empty;

  public enum RotateableEnum {
    yes,
    no,
    forcedRotation
  }

  // 1 order -> mange elementer.
  //FK til order
  public int TransportOrderId { get; set; }

  //Reference Navigation Property
  public Order? Order { get; set; }

 
}
