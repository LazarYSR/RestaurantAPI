using prj_RestaurantApi.Dao;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.Repo
{
    public class PlatRepo : PlatService
    {
        private readonly MyContext _db;
        public PlatRepo(MyContext db) 
        {
            _db = db;
        }   
        public Plat AJouterPlat(Plat p)
        {
            Plat plat = _db.Plats.FirstOrDefault(pl => pl.Id == p.Id );
            if (plat ==null)
            {
                return null;
            }
            _db.Plats.Add(plat);
            _db.SaveChanges();
            return plat;  
        }

        public Plat ChercherPlatByNom(string nom)
        {
            Plat pl = _db.Plats.FirstOrDefault(p => p.nom ==nom);
            if (pl ==null)
            { 
                return null;  
            }
            
            return pl ;
        }

        public Plat DeletePlat(int Id)
        {
            Plat pl = _db.Plats.FirstOrDefault(p => p.Id == Id);
            if (pl == null)
            {
                return null;
            }
            _db.Plats.Remove(pl);
            _db.SaveChanges();

            return pl;
        }

        public List<Plat> ListPlats()
        {
            if (!_db.Plats.ToList().Any())
            {
                return null;
            }
            return _db.Plats.ToList();
        }

        public Plat ModifierPlat(int Id,Plat plat)
        {
            Plat pl = _db.Plats.FirstOrDefault(p => p.Id == Id);
            if (pl == null)
            {
                return null;
            }
            pl.nom= plat.nom;
            pl.prix = plat.prix;
            pl.tempspreparation = plat.tempspreparation;    
            pl.categorie = plat.categorie;  
            pl.ingredients = plat.ingredients;  
            pl.nom = plat.nom;
            _db.SaveChanges();

            return pl;
        }
    }
}
