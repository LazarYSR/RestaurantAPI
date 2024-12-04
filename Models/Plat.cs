using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace prj_RestaurantApi.Models
{
    public class Plat
    {
        [Key]
        public int Id { get; set; }
        public string nom { get; set; }
        public string categorie { get; set; }
        public double prix { get; set; }
        public string jours { get; set; }
        public string ingredients { get; set; }
        public int tempspreparation { get; set; }
        public Collection<Commande> Commandes { get; set; }


    }
}
