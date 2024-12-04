using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.Controllers
{
    [Route("Commandes")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly CommandeService _commandeService;

        public CommandeController(CommandeService commandeService)
        {
            _commandeService = commandeService;
        }

        [HttpGet]
        public IActionResult GetAllCommandes()
        {
            var commandes = _commandeService.ListerCommandes();
            if (commandes == null || commandes.Count == 0)
            {
                return NotFound("Aucune commande trouvée.");
            }
            return Ok(commandes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommandeById(int id)
        {
            var commande = _commandeService.ChercherCommandeParId(id);
            if (commande == null)
            {
                return NotFound($"Commande avec l'ID {id} introuvable.");
            }
            return Ok(commande);
        }

        [HttpPost]
        public IActionResult AddCommande([FromBody] Commande commande)
        {
            var newCommande = _commandeService.AjouterCommande(commande);
            return CreatedAtAction(nameof(GetCommandeById), new { id = newCommande.Id }, newCommande);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCommande(int id, [FromBody] Commande commande)
        {
            var updatedCommande = _commandeService.ModifierCommande(id, commande);
            if (updatedCommande == null)
            {
                return NotFound($"Commande avec l'ID {id} introuvable.");
            }
            return Ok(updatedCommande);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCommande(int id)
        {
            Commande isDeleted = _commandeService.SupprimerCommande(id);
            if (isDeleted==null)
            {
                return NotFound($"Commande avec l'ID {id} introuvable.");
            }
            return Ok($"Commande avec l'ID {id} supprimée.");
        }
    }
}
