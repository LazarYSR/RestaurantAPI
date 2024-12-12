using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prj_RestaurantApi.Models
{
    public class Commande
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string categorie { get; set; }
        public double prix { get; set; } 
        public int jours { get; set; }
       
        public int quantite { get; set; }
        public DateTime dateCommande { get; set; }
        public double total { get; set; }
        public Employe employe { get; set; }
        public int employeId { get; set; }
    
        public Plat plat { get; set; }
        public int platId { get; set; }



    }
}
