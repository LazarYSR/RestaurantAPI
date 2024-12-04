using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace prj_RestaurantApi.Models
{
    public class Employe
    {
        [Key]
        public int Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string role { get; set; }
        public Collection<Commande> Commandes { get; set; }

    }
}
