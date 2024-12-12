using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prj_RestaurantApi.Models
{
    public class Plat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

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
