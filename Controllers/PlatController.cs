using Microsoft.AspNetCore.Mvc;
using prj_RestaurantApi.IServices;
using prj_RestaurantApi.Models;

namespace prj_RestaurantApi.Controllers
{
    [Route("Plats")]
    [ApiController]
    public class PlatController : ControllerBase
    {
        public readonly PlatService _platservice;
        public PlatController(PlatService platservice)
        {
            _platservice = platservice;   
        }
        [HttpGet]
        public ActionResult<IEnumerable<Plat>> GetPlats()
        {
            return Ok(_platservice);
        }

       
        [HttpGet("{nom}")]
        public ActionResult<Plat> GetPlatById(string nom)
        {
            var plat = _platservice.ChercherPlatByNom(nom);
            if (plat == null)
            {
                return NotFound($"Plat avec l'ID {nom} non trouvé.");
            }
            return Ok(plat);
        }

   
        [HttpPost]
        public ActionResult<Plat> CreatePlat(Plat newPlat)
        {
           
            if (newPlat == null)
            {
                return BadRequest("Les données du plat sont invalides.");
            }

            Plat plat = _platservice.AJouterPlat(newPlat);
            if (plat == null) 
            {
                return Conflict("Deja Existe");
            }

            return CreatedAtAction(nameof(GetPlatById), new { id = newPlat.Id }, newPlat);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlat(int id, Plat updatedPlat)
        {
    
            if (id != updatedPlat.Id)
            {
                return BadRequest($"Plat avec l'ID {id} non trouvé.");
            }

            Plat plat = _platservice.ModifierPlat(id, updatedPlat);
            if (plat == null)
            {
                return NotFound($"Plat avec l'ID {id} non trouvé.");
            }
       
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlat(int id)
        {
            var plat = _platservice.DeletePlat(id);
            if (plat == null)
            {
                return NotFound($"Plat avec l'ID {id} non trouvé.");
            }
            return NoContent();
        }
    }
}
