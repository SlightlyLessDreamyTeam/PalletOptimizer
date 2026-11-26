using System.Collections;

namespace PackMan.Models;

public class Order {
  public int TransportOrderId { get; set; }
  public int RefOrderId { get; set; }
  public ICollection<Element> Elements { get; set; } = new  List<Element>();
}
