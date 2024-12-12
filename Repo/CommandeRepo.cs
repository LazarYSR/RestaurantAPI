using prj_RestaurantApi.Dao;
using prj_RestaurantApi.Dto;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace prj_RestaurantApi.Services
{
    public class CommandeRepo : CommandeService
    {
        private readonly MyContext _db;

        public CommandeRepo(MyContext db)
        {
            _db = db;
        }

        public CommandeDto AjouterCommande(CommandeDto commandeDto)
        {
            // Conversion du DTO en entité
            var commande = new Commande
            {
                categorie = commandeDto.categorie,
                prix = commandeDto.prix,
                jours = commandeDto.jours,
                quantite = commandeDto.quantite,
                dateCommande = commandeDto.dateCommande,
                total = commandeDto.total,
                employeId = commandeDto.employeId,
                platId = commandeDto.platId
            };

            _db.Commandes.Add(commande);
            _db.SaveChanges();

            // Conversion de l'entité en DTO
            return new CommandeDto
            {
                Id = commande.Id,
                categorie = commande.categorie,
                prix = commande.prix,
                jours = commande.jours,
                quantite = commande.quantite,
                dateCommande = commande.dateCommande,
                total = commande.total,
                employeId = commande.employeId,
                platId = commande.platId
            };
        }

        public CommandeDto ModifierCommande(int id, CommandeDto updatedCommande)
        {
            var com = _db.Commandes.FirstOrDefault(p => p.Id == id);
            if (com == null) return null;

            // Mise à jour des propriétés
            com.categorie = updatedCommande.categorie;
            com.prix = updatedCommande.prix;
            com.jours = updatedCommande.jours;
            com.quantite = updatedCommande.quantite;
            com.dateCommande = updatedCommande.dateCommande;
            com.total = updatedCommande.total;
            com.employeId = updatedCommande.employeId;
            com.platId = updatedCommande.platId;

            _db.SaveChanges();

            // Conversion de l'entité mise à jour en DTO
            return new CommandeDto
            {
                Id = com.Id,
                categorie = com.categorie,
                prix = com.prix,
                jours = com.jours,
                quantite = com.quantite,
                dateCommande = com.dateCommande,
                total = com.total,
                employeId = com.employeId,
                platId = com.platId
            };
        }

        public CommandeDto ChercherCommandeParId(int id)
        {
            var commande = _db.Commandes.FirstOrDefault(c => c.Id == id);
            if (commande == null) return null;

            // Conversion de l'entité en DTO
            return new CommandeDto
            {
                Id = commande.Id,
                categorie = commande.categorie,
                prix = commande.prix,
                jours = commande.jours,
                quantite = commande.quantite,
                dateCommande = commande.dateCommande,
                total = commande.total,
                employeId = commande.employeId,
                platId = commande.platId
            };
        }

        public List<CommandeDto> ListerCommandes()
        {
            var commandes = _db.Commandes.ToList();

            return commandes.Select(c => new CommandeDto
            {
                Id = c.Id,
                categorie = c.categorie,
                prix = c.prix,
                jours = c.jours,
                quantite = c.quantite,
                dateCommande = c.dateCommande,
                total = c.total,
                employeId = c.employeId,
                platId = c.platId
            }).ToList();
        }

        public CommandeDto SupprimerCommande(int id)
        {
            var commande = _db.Commandes.FirstOrDefault(c => c.Id == id);
            if (commande == null) return null;

            _db.Commandes.Remove(commande);
            _db.SaveChanges();

            // Conversion de l'entité supprimée en DTO
            return new CommandeDto
            {
                Id = commande.Id,
                categorie = commande.categorie,
                prix = commande.prix,
                jours = commande.jours,
                quantite = commande.quantite,
                dateCommande = commande.dateCommande,
                total = commande.total,
                employeId = commande.employeId,
                platId = commande.platId
            };
        }
    }
}
