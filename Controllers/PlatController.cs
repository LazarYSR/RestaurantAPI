using Microsoft.AspNetCore.Mvc;
using prj_RestaurantApi.Dto;
using prj_RestaurantApi.IServices;
using System.Collections.Generic;

namespace prj_RestaurantApi.Controllers
{
    [Route("api/Plats")]
    [ApiController]
    public class PlatController : ControllerBase
    {
        private readonly PlatService _platService;

        public PlatController(PlatService platService)
        {
            _platService = platService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatDto>> GetPlats()
        {
            var plats = _platService.ListPlats();
            if (plats == null || plats.Count == 0)
            {
                return NotFound("Aucun plat trouvé.");
            }
            return Ok(plats);
        }

        [HttpGet("{id}")]
        public ActionResult<PlatDto> GetPlatById(int id)
        {
            var plat = _platService.ChercherPlatById(id);
            if (plat == null)
            {
                return NotFound($"Plat avec le nom '{id}' non trouvé.");
            }
            return Ok(plat);
        }

        [HttpPost]
        public ActionResult<PlatDto> CreatePlat([FromBody] PlatDto newPlatDto)
        {
            if (newPlatDto == null)
            {
                return BadRequest("Les données du plat sont invalides.");
            }

            var newPlat = _platService.AJouterPlat(newPlatDto);
            if (newPlat == null)
            {
                return Conflict("Le plat existe déjà.");
            }

            return CreatedAtAction(nameof(GetPlatById), new { nom = newPlat.nom }, newPlat);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlat(int id, [FromBody] PlatDto updatedPlatDto)
        {
            if (updatedPlatDto == null || id != updatedPlatDto.Id)
            {
                return BadRequest("Les données du plat sont invalides.");
            }

            var updatedPlat = _platService.ModifierPlat(id, updatedPlatDto);
            if (updatedPlat == null)
            {
                return NotFound($"Plat avec l'ID {id} non trouvé.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlat(int id)
        {
            var plat = _platService.DeletePlat(id);
            if (plat == null)
            {
                return NotFound($"Plat avec l'ID {id} non trouvé.");
            }
            return NoContent();
        }
    }
}
