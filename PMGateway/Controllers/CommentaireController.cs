using Microsoft.AspNetCore.Mvc;
using PMGateway.Services;
using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaireController : ControllerBase
    {
        private readonly ICommentaireService _commentaireService;

        public CommentaireController(ICommentaireService commentaireService)
        {
            _commentaireService = commentaireService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Commentaire>> GetCommentaire(int id)
        {
            var commentaire = await _commentaireService.GetCommentaireByIdAsync(id);
            if (commentaire == null)
            {
                return NotFound();
            }
            return Ok(commentaire);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commentaire>>> GetAllCommentaires()
        {
            var commentaires = await _commentaireService.GetAllCommentairesAsync();
            return Ok(commentaires);
        }

        [HttpPost]
        public async Task<ActionResult> AddCommentaire([FromBody] Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _commentaireService.AddCommentaireAsync(commentaire);
            return CreatedAtAction(nameof(GetCommentaire), new { id = commentaire.Id }, commentaire);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommentaire(int id, [FromBody] Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            commentaire.Id = id;
            await _commentaireService.UpdateCommentaireAsync(commentaire);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommentaire(int id)
        {
            await _commentaireService.DeleteCommentaireAsync(id);
            return NoContent();
        }
    }
}
