using PackMan.Models;

namespace PackMan.Repositories {
  public interface IElementRepository {

    Element? GetElementById(int id);
    void AddElement(Element element);
    void UpdateElement(Element element);
    void DeleteElement(int id);
  }
}
