using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.IServices
{
    public interface PlatService
    {
        Plat AJouterPlat(Plat plat);
        Plat DeletePlat(int Id);
        Plat ModifierPlat(int Id,Plat plat);
        Plat ChercherPlatByNom(string nom);
        List<Plat> ListPlats();
    }
}
