using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.IServices
{
    public interface EmployeService
    {
        Employe AjouterEmploye(Employe employe);
        Employe ChercherEmployeParId(int id);
        List<Employe> ListerEmployes();
        Employe ModifierEmploye(int id, Employe employe);
        Employe SupprimerEmploye(int id);
    }
}
