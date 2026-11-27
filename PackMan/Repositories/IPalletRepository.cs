using PackMan.Models;

namespace PackMan.Repositories {
  public interface IPalletRepository {
    Pallet? GetPalletById(int id);
    void AddPallet(Pallet pallet);
    void UpdatePallet(Pallet pallet);
    void DeletePallet(int id);
  }
}
