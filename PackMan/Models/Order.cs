using System.Collections;


namespace PackMan.Models;

public class Order {
  int TransportOrderId { get; set; }
  int RefOrderId { get; set; }
  public List<Element> Elements { get; set; } = new List<Element>();
}
