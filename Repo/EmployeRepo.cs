using prj_RestaurantApi.Dao;
using prj_RestaurantApi.Dto;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace prj_RestaurantApi.Repo
{
    public class EmployeRepo : EmployeService
    {
        private readonly MyContext _db;

        public EmployeRepo(MyContext db)
        {
            _db = db;
        }

        public EmployeDto AjouterEmploye(EmployeDto employeDto)
        {
            if (employeDto == null || string.IsNullOrEmpty(employeDto.Nom) || string.IsNullOrEmpty(employeDto.Prenom))
            {
                return null;
            }

            var employe = new Employe
            {
                nom = employeDto.Nom,
                prenom = employeDto.Prenom,
                role = employeDto.Role,
                Commandes = null // Si vous avez besoin d'initialiser la collection
            };

            _db.Employes.Add(employe);
            _db.SaveChanges();

            // Retourner l'objet DTO mis à jour
            employeDto.Id = employe.Id; // Assurez-vous que l'ID est mis à jour après l'ajout
            return employeDto;
        }

        public EmployeDto ChercherEmployeParId(int id)
        {
            var employe = _db.Employes.FirstOrDefault(e => e.Id == id);
            if (employe == null)
            {
                return null;
            }

            return new EmployeDto
            {
                Id = employe.Id,
                Nom = employe.nom,
                Prenom = employe.prenom,
                Role = employe.role
            };
        }

        public List<EmployeDto> ListerEmployes()
        {
            var employes = _db.Employes.ToList();

            return employes.Select(e => new EmployeDto
            {
                Id = e.Id,
                Nom = e.nom,
                Prenom = e.prenom,
                Role = e.role
            }).ToList();
        }

        public EmployeDto SupprimerEmploye(int id)
        {
            var employe = _db.Employes.FirstOrDefault(e => e.Id == id);
            if (employe == null) return null;

            _db.Employes.Remove(employe);
            _db.SaveChanges();

            return new EmployeDto
            {
                Id = employe.Id,
                Nom = employe.nom,
                Prenom = employe.prenom,
                Role = employe.role
            };
        }

        public EmployeDto ModifierEmploye(int id, EmployeDto employeDto)
        {
            var existingEmploye = _db.Employes.FirstOrDefault(e => e.Id == id);
            if (existingEmploye == null)
                return null;

            existingEmploye.nom = employeDto.Nom;
            existingEmploye.prenom = employeDto.Prenom;
            existingEmploye.role = employeDto.Role;

            _db.SaveChanges();

            return new EmployeDto
            {
                Id = existingEmploye.Id,
                Nom = existingEmploye.nom,
                Prenom = existingEmploye.prenom,
                Role = existingEmploye.role
            };
        }
    }
}
