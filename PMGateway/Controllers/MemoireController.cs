using Microsoft.AspNetCore.Mvc;
using PMGateway.Services;
using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemoireController : ControllerBase
    {
        private readonly IMemoireService _memoireService;

        public MemoireController(IMemoireService memoireService)
        {
            _memoireService = memoireService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Memoire>> GetMemoire(int id)
        {
            var memoire = await _memoireService.GetMemoireByIdAsync(id);
            if (memoire == null)
            {
                return NotFound();
            }
            return Ok(memoire);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Memoire>>> GetAllMemoires()
        {
            var memoires = await _memoireService.GetAllMemoiresAsync();
            return Ok(memoires);
        }

        [HttpPost]
        public async Task<ActionResult> AddMemoire([FromBody] Memoire memoire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _memoireService.AddMemoireAsync(memoire);
            return CreatedAtAction(nameof(GetMemoire), new { id = memoire.Id }, memoire);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMemoire(int id, [FromBody] Memoire memoire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            memoire.Id = id;
            await _memoireService.UpdateMemoireAsync(memoire);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMemoire(int id)
        {
            await _memoireService.DeleteMemoireAsync(id);
            return NoContent();
        }
    }
}
