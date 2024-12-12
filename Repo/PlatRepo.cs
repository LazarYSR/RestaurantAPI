using prj_RestaurantApi.Dao;
using prj_RestaurantApi.Dto;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace prj_RestaurantApi.Repo
{
    public class PlatRepo : PlatService
    {
        private readonly MyContext _db;

        public PlatRepo(MyContext db)
        {
            _db = db;
        }

        public PlatDto AJouterPlat(PlatDto platDto)
        {
            // Vérification de l'existence du plat par son nom ou ID si nécessaire
            var plat = _db.Plats.FirstOrDefault(pl => pl.nom == platDto.nom);
            if (plat != null)
            {
                // Si le plat existe déjà, retourner null ou gérer selon la logique métier
                return null;
            }

            // Conversion du DTO en entité
            var newPlat = new Plat
            {
                nom = platDto.nom,
                categorie = platDto.categorie,
                prix = platDto.prix,
                jours = platDto.jours,
                ingredients = platDto.ingredients,
                tempspreparation = platDto.tempspreparation
            };

            _db.Plats.Add(newPlat);
            _db.SaveChanges();

            // Conversion de l'entité en DTO
            return new PlatDto
            {
                Id = newPlat.Id,
                nom = newPlat.nom,
                categorie = newPlat.categorie,
                prix = newPlat.prix,
                jours = newPlat.jours,
                ingredients = newPlat.ingredients,
                tempspreparation = newPlat.tempspreparation
            };
        }

        public PlatDto ChercherPlatByNom(string nom)
        {
            var plat = _db.Plats.FirstOrDefault(p => p.nom == nom);
            if (plat == null)
            {
                return null;
            }

            // Conversion de l'entité en DTO
            return new PlatDto
            {
                Id = plat.Id,
                nom = plat.nom,
                categorie = plat.categorie,
                prix = plat.prix,
                jours = plat.jours,
                ingredients = plat.ingredients,
                tempspreparation = plat.tempspreparation
            };
        }

        public PlatDto DeletePlat(int Id)
        {
            var plat = _db.Plats.FirstOrDefault(p => p.Id == Id);
            if (plat == null)
            {
                return null;
            }

            _db.Plats.Remove(plat);
            _db.SaveChanges();

            // Conversion de l'entité supprimée en DTO
            return new PlatDto
            {
                Id = plat.Id,
                nom = plat.nom,
                categorie = plat.categorie,
                prix = plat.prix,
                jours = plat.jours,
                ingredients = plat.ingredients,
                tempspreparation = plat.tempspreparation
            };
        }

        public List<PlatDto> ListPlats()
        {
            var plats = _db.Plats.ToList();
            if (!plats.Any())
            {
                return null;
            }

            return plats.Select(p => new PlatDto
            {
                Id = p.Id,
                nom = p.nom,
                categorie = p.categorie,
                prix = p.prix,
                jours = p.jours,
                ingredients = p.ingredients,
                tempspreparation = p.tempspreparation
            }).ToList();
        }

        public PlatDto ModifierPlat(int Id, PlatDto platDto)
        {
            var plat = _db.Plats.FirstOrDefault(p => p.Id == Id);
            if (plat == null)
            {
                return null;
            }

            // Mise à jour des propriétés
            plat.nom = platDto.nom;
            plat.prix = platDto.prix;
            plat.tempspreparation = platDto.tempspreparation;
            plat.categorie = platDto.categorie;
            plat.ingredients = platDto.ingredients;

            _db.SaveChanges();

            // Conversion de l'entité mise à jour en DTO
            return new PlatDto
            {
                Id = plat.Id,
                nom = plat.nom,
                categorie = plat.categorie,
                prix = plat.prix,
                jours = plat.jours,
                ingredients = plat.ingredients,
                tempspreparation = plat.tempspreparation
            };
        }
    }
}
