using prj_RestaurantApi.Dto;
using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.IServices
{
    public interface EmployeService
    {
        EmployeDto AjouterEmploye(EmployeDto employe);
        EmployeDto ChercherEmployeParId(int id);
        List<EmployeDto> ListerEmployes();
        EmployeDto ModifierEmploye(int id, EmployeDto employe);
        EmployeDto SupprimerEmploye(int id);
    }
}
