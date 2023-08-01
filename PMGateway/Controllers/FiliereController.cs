using Microsoft.AspNetCore.Mvc;
using PMGateway.Services;
using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiliereController : ControllerBase
    {
        private readonly IFiliereService _filiereService;

        public FiliereController(IFiliereService filiereService)
        {
            _filiereService = filiereService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filiere>> GetFiliere(int id)
        {
            var filiere = await _filiereService.GetFiliereByIdAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }
            return Ok(filiere);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filiere>>> GetAllFilieres()
        {
            var filieres = await _filiereService.GetAllFilieresAsync();
            return Ok(filieres);
        }

        [HttpPost]
        public async Task<ActionResult> AddFiliere([FromBody] Filiere filiere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _filiereService.AddFiliereAsync(filiere);
            return CreatedAtAction(nameof(GetFiliere), new { id = filiere.Id }, filiere);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFiliere(int id, [FromBody] Filiere filiere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            filiere.Id = id;
            await _filiereService.UpdateFiliereAsync(filiere);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFiliere(int id)
        {
            await _filiereService.DeleteFiliereAsync(id);
            return NoContent();
        }
    }
}
