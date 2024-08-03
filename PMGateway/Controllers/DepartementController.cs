using Microsoft.AspNetCore.Mvc;
using PMGateway.Services;
using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        private readonly IDepartementService _departementService;

        public DepartementController(IDepartementService departementService)
        {
            _departementService = departementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departement>>> GetAllDepartements()
        {
            var departements = await _departementService.GetAllDepartementsAsync();
            return Ok(departements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departement>> GetDepartement(int id)
        {
            var departement = await _departementService.GetDepartementByIdAsync(id);
            if (departement == null)
            {
                return NotFound();
            }
            return Ok(departement);
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartement([FromBody] Departement departement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _departementService.AddDepartementAsync(departement);
            return CreatedAtAction(nameof(GetDepartement), new { id = departement.Id }, departement);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartement(int id, [FromBody] Departement departement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            departement.Id = id;
            await _departementService.UpdateDepartementAsync(departement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartement(int id)
        {
            await _departementService.DeleteDepartementAsync(id);
            return NoContent();
        }
    }
}
