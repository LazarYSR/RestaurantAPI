using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.IServices
{
    public interface CommandeService
    {
        Commande AjouterCommande(Commande commande);
        Commande ModifierCommande(int id, Commande commande);
        Commande ChercherCommandeParId(int id);
        List<Commande> ListerCommandes();
        Commande SupprimerCommande(int id);
    }
}
