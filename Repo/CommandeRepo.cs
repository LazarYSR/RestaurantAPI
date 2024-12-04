using prj_RestaurantApi.Dao;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.Repo
{
    public class CommandeRepo : CommandeService
    {
        private readonly MyContext _db;

        public CommandeRepo(MyContext db)
        {
            _db = db;
        }

        public Commande AjouterCommande(Commande commande)
        {
            _db.Commandes.Add(commande);
            _db.SaveChanges();
            return commande;
        }

        public Commande ChercherCommandeParId(int id)
        {
            return _db.Commandes.FirstOrDefault(c => c.Id == id);
        }

        public List<Commande> ListerCommandes()
        {
            return _db.Commandes.ToList();
        }

        public Commande SupprimerCommande(int id)
        {
            var commande = _db.Commandes.FirstOrDefault(c => c.Id == id);
            if (commande == null) return null;

            _db.Commandes.Remove(commande);
            _db.SaveChanges();
            return commande;
        }

        public Commande ModifierCommande(int id, Commande commande)
        {
            var existingCommande = _db.Commandes.FirstOrDefault(c => c.Id == id);
            if (existingCommande == null) 
                return null;


            existingCommande.prix = commande.prix;
            existingCommande.jours = commande.jours;
            existingCommande.quantite = commande.quantite;
            existingCommande.categorie = commande.categorie;
            existingCommande.dateCommande = commande.dateCommande;
            existingCommande.employeId = commande.employeId;
            existingCommande.platId = commande.platId;

            _db.SaveChanges();
            return existingCommande;
        }

        
    }
}
