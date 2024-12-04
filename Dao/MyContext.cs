using Microsoft.EntityFrameworkCore;
using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.Dao
{
    public class MyContext :DbContext
    {
        public DbSet<Plat> Plats { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public MyContext(DbContextOptions<MyContext> opt):base(opt)
        { 

        }
    }
}
