using Microsoft.AspNetCore.Mvc;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;
using System.Collections.Generic;

namespace prj_RestaurantApi.Controllers
{
    [Route("Employes")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly EmployeService _employeService;

        public EmployeController(EmployeService employeService)
        {
            _employeService = employeService;
        }


        [HttpPost("Add")]
        public IActionResult AjouterEmploye([FromBody] Employe employe)
        {
            if (employe == null || string.IsNullOrEmpty(employe.nom) || string.IsNullOrEmpty(employe.prenom))
            {
                return BadRequest("Les informations de l'employé sont invalides.");
            }

            var newEmploye = _employeService.AjouterEmploye(employe);
            if (newEmploye == null)
            {
                return BadRequest("Erreur lors de l'ajout de l'employé.");
            }

            return Ok(newEmploye);
        }

      
        [HttpGet("{id}")]
        public IActionResult ChercherEmployeParId(int id)
        {
            var employe = _employeService.ChercherEmployeParId(id);
            if (employe == null)
            {
                return NotFound($"Aucun employé trouvé avec l'ID {id}.");
            }

            return Ok(employe);
        }
        [HttpGet]
        public IActionResult ListerEmployes()
        {
            var employes = _employeService.ListerEmployes();
            if (employes == null || employes.Count == 0)
            {
                return NotFound("Aucun employé trouvé.");
            }

            return Ok(employes);
        }

  
        [HttpDelete("{id}")]
        public IActionResult SupprimerEmploye(int id)
        {
            var deletedEmploye = _employeService.SupprimerEmploye(id);
            if (deletedEmploye == null)
            {
                return NotFound($"Aucun employé trouvé avec l'ID {id}.");
            }

            return Ok(deletedEmploye);
        }


        [HttpPut("{id}")]
        public IActionResult ModifierEmploye(int id, [FromBody] Employe employe)
        {
            if (employe == null || string.IsNullOrEmpty(employe.nom) || string.IsNullOrEmpty(employe.prenom))
            {
                return BadRequest("Les informations de l'employé sont invalides.");
            }

            var updatedEmploye = _employeService.ModifierEmploye(id, employe);
            if (updatedEmploye == null)
            {
                return NotFound($"Aucun employé trouvé avec l'ID {id}.");
            }

            return Ok(updatedEmploye);
        }
    }
}
