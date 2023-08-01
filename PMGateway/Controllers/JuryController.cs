using Microsoft.AspNetCore.Mvc;
using PMGateway.Services;
using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuryController : ControllerBase
    {
        private readonly IJuryService _juryService;

        public JuryController(IJuryService juryService)
        {
            _juryService = juryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jury>> GetJury(int id)
        {
            var jury = await _juryService.GetJuryByIdAsync(id);
            if (jury == null)
            {
                return NotFound();
            }
            return Ok(jury);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jury>>> GetAllJuries()
        {
            var juries = await _juryService.GetAllJuriesAsync();
            return Ok(juries);
        }

        [HttpPost]
        public async Task<ActionResult> AddJury([FromBody] Jury jury)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _juryService.AddJuryAsync(jury);
            return CreatedAtAction(nameof(GetJury), new { id = jury.Id }, jury);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateJury(int id, [FromBody] Jury jury)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            jury.Id = id;
            await _juryService.UpdateJuryAsync(jury);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteJury(int id)
        {
            await _juryService.DeleteJuryAsync(id);
            return NoContent();
        }
    }
}
