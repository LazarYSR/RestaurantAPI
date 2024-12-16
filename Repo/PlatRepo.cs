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
            
            var plat = _db.Plats.FirstOrDefault(pl => pl.nom == platDto.nom);
            if (plat != null)
            {
              
                return null;
            }

           
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

        public PlatDto ChercherPlatById(int id)
        {
            var plat = _db.Plats.FirstOrDefault(p => p.Id == id);
            if (plat == null)
            {
                return null;
            }

           
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

     
            plat.nom = platDto.nom;
            plat.prix = platDto.prix;
            plat.tempspreparation = platDto.tempspreparation;
            plat.categorie = platDto.categorie;
            plat.ingredients = platDto.ingredients;

            _db.SaveChanges();

           
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
