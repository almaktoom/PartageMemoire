using Microsoft.AspNetCore.Mvc;
using PMGateway.Services;
using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private readonly IEtudiantService _etudiantService;

        public EtudiantController(IEtudiantService etudiantService)
        {
            _etudiantService = etudiantService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> GetEtudiant(int id)
        {
            var etudiant = await _etudiantService.GetEtudiantByIdAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return Ok(etudiant);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etudiant>>> GetAllEtudiants()
        {
            var etudiants = await _etudiantService.GetAllEtudiantsAsync();
            return Ok(etudiants);
        }

        [HttpPost]
        public async Task<ActionResult> AddEtudiant([FromBody] Etudiant etudiant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _etudiantService.AddEtudiantAsync(etudiant);
            return CreatedAtAction(nameof(GetEtudiant), new { id = etudiant.Id }, etudiant);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEtudiant(int id, [FromBody] Etudiant etudiant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            etudiant.Id = id;
            await _etudiantService.UpdateEtudiantAsync(etudiant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEtudiant(int id)
        {
            await _etudiantService.DeleteEtudiantAsync(id);
            return NoContent();
        }
    }
}
