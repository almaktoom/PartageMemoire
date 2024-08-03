using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Services
{
    public interface ICommentaireService
    {
        Task<Commentaire> GetCommentaireByIdAsync(int id);
        Task<IEnumerable<Commentaire>> GetAllCommentairesAsync();
        Task AddCommentaireAsync(Commentaire commentaire);
        Task UpdateCommentaireAsync(Commentaire commentaire);
        Task DeleteCommentaireAsync(int id);
    }

    public class CommentaireService : ICommentaireService
    {
        private readonly Service1Client _client;

        public CommentaireService(Service1Client client)
        {
            _client = client;
        }

        public async Task<Commentaire> GetCommentaireByIdAsync(int id)
        {
            return await _client.GetCommentaireByIdAsync(id);
        }

        public async Task<IEnumerable<Commentaire>> GetAllCommentairesAsync()
        {
            return await _client.GetAllCommentairesAsync();
        }

        public async Task AddCommentaireAsync(Commentaire commentaire)
        {
            await _client.AddCommentaireAsync(commentaire);
        }

        public async Task UpdateCommentaireAsync(Commentaire commentaire)
        {
            await _client.UpdateCommentaireAsync(commentaire);
        }

        public async Task DeleteCommentaireAsync(int id)
        {
            await _client.DeleteCommentaireAsync(id);
        }
    }
}
