using System.Xml;
using Microsoft.AspNetCore.Mvc;
using PackMan.Models;

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

    try {
      XmlReaderSettings settings = new XmlReaderSettings();
      settings.IgnoreComments = true;
      settings.IgnoreWhitespace = true;

      using XmlReader reader = XmlReader.Create(file.OpenReadStream(), settings);
      SaveOrders(reader);
      }
    catch (IOException) {
      Console.WriteLine("Could not read XMLfile");
    }

      ViewData["Message"] = $"Ordrer fra filen '{file.FileName}' er blevet tilføjet.";
    return RedirectToAction("Orders", "Orders");
  }

  public bool SaveOrders(XmlReader reader)
    {
        Order? currentOrder = null;
        Element? currentElement = null;

        reader.MoveToContent();

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                switch (reader.Name)
                {
                    case "Order":
                        currentOrder = new Order
                        {
                            RefOrderId = int.Parse(
                                reader.GetAttribute("RefOrderId")!)
                        };
                        break;

                    case "Element":
                        currentElement = new Element();
                        break;

                    case "ElementId":
                        currentElement!.ElementId = reader.ReadElementContentAsInt();
                        break;

                    case "Rotate":
                        currentElement!.Rotate =
                            Enum.Parse<Element.RotateableEnum>(
                                reader.ReadElementContentAsString());
                        break;

                    case "RequireSpecialPallet":
                        currentElement!.RequireSpecialPallet =
                            reader.ReadElementContentAsBoolean();
                        break;

                    case "Length":
                        currentElement!.Length = reader.ReadElementContentAsInt();
                        break;

                    case "Width":
                        currentElement!.Width = reader.ReadElementContentAsInt();
                        break;

                    case "Height":
                        currentElement!.Height = reader.ReadElementContentAsInt();
                        break;

                    case "Weight":
                        currentElement!.Weight = reader.ReadElementContentAsInt();
                        break;

                    case "Series":
                        currentElement!.Series = reader.ReadElementContentAsString();
                        break;

                    case "Brand":
                        currentElement!.Brand = reader.ReadElementContentAsString();
                        break;
                }
            }
            else if (reader.NodeType == XmlNodeType.EndElement)
            {
                if (reader.Name == "Element" && currentElement != null)
                {
                    currentOrder!.Elements.Add(currentElement);
                    currentElement = null;
                }

                if (reader.Name == "Order" && currentOrder != null)
                {
                  Console.WriteLine("orderready to be saved");
                    // TODO: Save currentOrder to database using Entity Framework.

                    currentOrder = null;
                }
            }
        }

        return true;
    }
}
