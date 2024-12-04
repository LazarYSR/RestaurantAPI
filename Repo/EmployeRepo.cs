using prj_RestaurantApi.Dao;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;
using System.Collections.Generic;
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

     
        public Employe AjouterEmploye(Employe employe)
        {
            if (employe == null || string.IsNullOrEmpty(employe.nom) || string.IsNullOrEmpty(employe.prenom))
            {
                return null;
            }

            _db.Employes.Add(employe);
            _db.SaveChanges();
            return employe;
        }

        public Employe ChercherEmployeParId(int id)
        {
            return _db.Employes.FirstOrDefault(e => e.Id == id);
        }

       
        public List<Employe> ListerEmployes()
        {
            return _db.Employes.ToList();
        }

      
        public Employe SupprimerEmploye(int id)
        {
            var employe = _db.Employes.FirstOrDefault(e => e.Id == id);
            if (employe == null) return null;

            _db.Employes.Remove(employe);
            _db.SaveChanges();
            return employe;
        }

       
        public Employe ModifierEmploye(int id, Employe employe)
        {
            var existingEmploye = _db.Employes.FirstOrDefault(e => e.Id == id);
            if (existingEmploye == null)
                return null;

            existingEmploye.nom = employe.nom;
            existingEmploye.prenom = employe.prenom;
            existingEmploye.role = employe.role;

            _db.SaveChanges();
            return existingEmploye;
        }
    }
}
