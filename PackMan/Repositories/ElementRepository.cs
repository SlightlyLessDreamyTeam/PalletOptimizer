using PackMan.Data;
using PackMan.Models;

namespace PackMan.Repositories {
  public class ElementRepository : IElementRepository {

    private readonly PackManDbContext _context;
    public ElementRepository(PackManDbContext context) {
      _context = context;
    }
    public Element? GetElementById(int id) {
      return _context.Elements.FirstOrDefault(e => e.ElementId == id);
    }
    public void AddElement(Element element) {
      _context.Elements.Add(element);
      _context.SaveChanges();
    }
    public void UpdateElement(Element element) {
      _context.Elements.Update(element);
      _context.SaveChanges();
    }
    public void DeleteElement(int id) {
      var element = GetElementById(id);
      if (element != null) {
        _context.Elements.Remove(element);
        _context.SaveChanges();
      }
    }
  }
}
