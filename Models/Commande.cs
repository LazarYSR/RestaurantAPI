using System.ComponentModel.DataAnnotations;

namespace prj_RestaurantApi.Models
{
    public class Commande
    {
        [Key]
        public int Id { get; set; }
       
        public string categorie { get; set; }
        public double prix { get; set; } 
        public int jours { get; set; }
       
        public int quantite { get; set; }
        public DateTime dateCommande { get; set; }
        public double total { get; set; }
        public Employe employeId { get; set; }
        public Plat platId { get; set; }



    }
}
