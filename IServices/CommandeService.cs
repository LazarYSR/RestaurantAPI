using prj_RestaurantApi.Dto;
using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.IServices
{
    public interface CommandeService
    {
        CommandeDto AjouterCommande(CommandeDto commande);
        CommandeDto ModifierCommande(int id, CommandeDto commande);
        CommandeDto ChercherCommandeParId(int id);
        List<CommandeDto> ListerCommandes();
        CommandeDto SupprimerCommande(int id);
    }
}
