using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.Dto
{
    public class CommandeDto
    {
        public int Id { get; set; }
         
        public string categorie { get; set; }
        public double prix { get; set; }
        public int jours { get; set; }

        public int quantite { get; set; }
        public DateTime dateCommande { get; set; }
        public double total { get; set; }
        public int employeId { get; set; }
        public int platId { get; set; }
    }
}
