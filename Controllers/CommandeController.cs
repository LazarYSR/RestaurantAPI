using Microsoft.AspNetCore.Mvc;
using prj_RestaurantApi.Dto;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;
using System.Collections.Generic;

namespace prj_RestaurantApi.Controllers
{
    [Route("api/Commandes")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly CommandeService _commandeService;

        public CommandeController(CommandeService commandeService)
        {
            _commandeService = commandeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Commande>> GetAllCommandes()
        {
            var commandes = _commandeService.ListerCommandes();
            if (commandes == null || commandes.Count == 0)
            {
                return NotFound("Aucune commande trouvée.");
            }
            return Ok(commandes);
        }

        [HttpGet("{id}")]
        public ActionResult<Commande> GetCommandeById(int id)
        {
            var commande = _commandeService.ChercherCommandeParId(id);
            if (commande == null)
            {
                return NotFound($"Commande avec l'ID {id} introuvable.");
            }
            return Ok(commande);
        }

        [HttpPost]
        public ActionResult<Commande> AddCommande(CommandeDto commande)
        {
            if (commande == null)
            {
                return BadRequest("Les informations de la commande sont invalides.");
            }

            var newCommande = _commandeService.AjouterCommande(commande);
            return CreatedAtAction(nameof(GetCommandeById), new { id = newCommande.Id }, newCommande);
        }

        [HttpPut("{id}")]
        public ActionResult<Commande> UpdateCommande(int id, CommandeDto commande)
        {
            if (commande == null)
            {
                return BadRequest("Les informations de la commande sont invalides.");
            }

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
            var isDeleted = _commandeService.SupprimerCommande(id);
            if (isDeleted == null)
            {
                return NotFound($"Commande avec l'ID {id} introuvable.");
            }
            return NoContent(); // Utiliser NoContent pour indiquer la suppression réussie
        }
    }
}
