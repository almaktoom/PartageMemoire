using Microsoft.AspNetCore.Mvc;
using PMGateway.Services;
using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesseurController : ControllerBase
    {
        private readonly IProfesseurService _professeurService;

        public ProfesseurController(IProfesseurService professeurService)
        {
            _professeurService = professeurService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professeur>> GetProfesseur(int id)
        {
            var professeur = await _professeurService.GetProfesseurByIdAsync(id);
            if (professeur == null)
            {
                return NotFound();
            }
            return Ok(professeur);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professeur>>> GetAllProfesseurs()
        {
            var professeurs = await _professeurService.GetAllProfesseursAsync();
            return Ok(professeurs);
        }

        [HttpPost]
        public async Task<ActionResult> AddProfesseur([FromBody] Professeur professeur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _professeurService.AddProfesseurAsync(professeur);
            return CreatedAtAction(nameof(GetProfesseur), new { id = professeur.Id }, professeur);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProfesseur(int id, [FromBody] Professeur professeur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            professeur.Id = id;
            await _professeurService.UpdateProfesseurAsync(professeur);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfesseur(int id)
        {
            await _professeurService.DeleteProfesseurAsync(id);
            return NoContent();
        }
    }
}
