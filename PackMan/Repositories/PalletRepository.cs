using PackMan.Data;
using PackMan.Models;

namespace PackMan.Repositories {
  public class PalletRepository : IPalletRepository {

    private readonly PackManDbContext _context;

    public PalletRepository(PackManDbContext context) {
      _context = context;
    }

    public Pallet? GetPalletById(int id) {
      return _context.Pallets.FirstOrDefault(p => p.Id == id);
    }

    public void AddPallet(Pallet pallet) {
      _context.Pallets.Add(pallet);
      _context.SaveChanges();
    }

    public void UpdatePallet(Pallet pallet) {
      _context.Pallets.Update(pallet);
      _context.SaveChanges();
    }

    public void DeletePallet(int id) {
      var pallet = GetPalletById(id);
      if (pallet != null) {
        _context.Pallets.Remove(pallet);
        _context.SaveChanges();
      }
    }
  }
}
