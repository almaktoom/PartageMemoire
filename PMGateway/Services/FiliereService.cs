using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Services
{
    public interface IFiliereService
    {
        Task<Filiere> GetFiliereByIdAsync(int id);
        Task<IEnumerable<Filiere>> GetAllFilieresAsync();
        Task AddFiliereAsync(Filiere filiere);
        Task UpdateFiliereAsync(Filiere filiere);
        Task DeleteFiliereAsync(int id);
    }

    public class FiliereService : IFiliereService
    {
        private readonly Service1Client _client;

        public FiliereService(Service1Client client)
        {
            _client = client;
        }

        public async Task<Filiere> GetFiliereByIdAsync(int id)
        {
            return await _client.GetFiliereByIdAsync(id);
        }

        public async Task<IEnumerable<Filiere>> GetAllFilieresAsync()
        {
            return await _client.GetAllFilieresAsync();
        }

        public async Task AddFiliereAsync(Filiere filiere)
        {
            await _client.AddFiliereAsync(filiere);
        }

        public async Task UpdateFiliereAsync(Filiere filiere)
        {
            await _client.UpdateFiliereAsync(filiere);
        }

        public async Task DeleteFiliereAsync(int id)
        {
            await _client.DeleteFiliereAsync(id);
        }
    }
}
