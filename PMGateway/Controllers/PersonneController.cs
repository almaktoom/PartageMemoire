using Microsoft.AspNetCore.Mvc;
using PMGateway.Services;
using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly IPersonneService _personneService;

        public PersonneController(IPersonneService personneService)
        {
            _personneService = personneService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personne>> GetPersonne(int id)
        {
            var personne = await _personneService.GetPersonneByIdAsync(id);
            if (personne == null)
            {
                return NotFound();
            }
            return Ok(personne);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personne>>> GetAllPersonnes()
        {
            var personnes = await _personneService.GetAllPersonnesAsync();
            return Ok(personnes);
        }

        [HttpPost]
        public async Task<ActionResult> AddPersonne([FromBody] Personne personne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personneService.AddPersonneAsync(personne);
            return CreatedAtAction(nameof(GetPersonne), new { id = personne.Id }, personne);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePersonne(int id, [FromBody] Personne personne)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            personne.Id = id;
            await _personneService.UpdatePersonneAsync(personne);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonne(int id)
        {
            await _personneService.DeletePersonneAsync(id);
            return NoContent();
        }
    }
}
