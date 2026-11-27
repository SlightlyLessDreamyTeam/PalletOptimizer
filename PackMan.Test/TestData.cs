using PackMan.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackMan.Test {
  public class TestData {
    public static Order CreateOrder() {
      return new Order { 
        RefOrderId = 543
      };
    }

    public static Pallet CreatePallet() {
      return new Pallet {
        Description = "Standard Pallet",
        length = 120,
        width = 80,
        palletType = Pallet.PalletType.wood,
        Weight = 25,
        MaxWeight = 1000,
        Overhang = 0,
        AirBetweenElements = 10,
        isActive = true
      };
    }

    public static Element CreateElement(Order order) {
      return new Element {
        Rotate = Element.RotateableEnum.yes,
        RequireSpecialPallet = false,
        Length = 10,
        Width = 20,
        Height = 30,
        Weight = 40,
        Series = "Serie A",
        Brand = "Velux",
        Order = order
      };
    }
  }
}
