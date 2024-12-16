using prj_RestaurantApi.Dto;
using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.IServices
{
    public interface PlatService
    {
        PlatDto AJouterPlat(PlatDto plat);
        PlatDto DeletePlat(int Id);
        PlatDto ModifierPlat(int Id,PlatDto plat);
        PlatDto ChercherPlatById(int id);
        List<PlatDto> ListPlats();
    }
}
