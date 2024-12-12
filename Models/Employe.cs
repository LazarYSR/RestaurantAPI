using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prj_RestaurantApi.Models
{
    public class Employe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string role { get; set; }
        public Collection<Commande> Commandes { get; set; }

    }
}
