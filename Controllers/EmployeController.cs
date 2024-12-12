using Microsoft.AspNetCore.Mvc;
using prj_RestaurantApi.Dto;
using prj_RestaurantApi.IServices;


namespace prj_RestaurantApi.Controllers
{
    [Route("api/Employes")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly EmployeService _employeService;

        public EmployeController(EmployeService employeService)
        {
            _employeService = employeService;
        }

        [HttpPost]
        public ActionResult<EmployeDto> AjouterEmploye(EmployeDto employe)
        {
            if (employe == null || string.IsNullOrEmpty(employe.Nom) || string.IsNullOrEmpty(employe.Prenom))
            {
                return BadRequest("Les informations de l'employé sont invalides.");
            }

            var newEmploye = _employeService.AjouterEmploye(employe);
            if (newEmploye == null)
            {
                return BadRequest("Erreur lors de l'ajout de l'employé.");
            }

            return CreatedAtAction(nameof(ChercherEmployeParId), new { id = newEmploye.Id }, newEmploye);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeDto> ChercherEmployeParId(int id)
        {
            var employe = _employeService.ChercherEmployeParId(id);
            if (employe == null)
            {
                return NotFound($"Aucun employé trouvé avec l'ID {id}.");
            }

            return Ok(employe);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeDto>> ListerEmployes()
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

            return NoContent(); // Réponse sans contenu pour indiquer que la suppression a été effectuée
        }

        [HttpPut("{id}")]
        public ActionResult<EmployeDto> ModifierEmploye(int id,EmployeDto employe)
        {
            if (employe == null || string.IsNullOrEmpty(employe.Nom) || string.IsNullOrEmpty(employe.Prenom))
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
