using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Services
{
    public interface IEtudiantService
    {
        Task<Etudiant> GetEtudiantByIdAsync(int id);
        Task<IEnumerable<Etudiant>> GetAllEtudiantsAsync();
        Task AddEtudiantAsync(Etudiant etudiant);
        Task UpdateEtudiantAsync(Etudiant etudiant);
        Task DeleteEtudiantAsync(int id);
    }

    public class EtudiantService : IEtudiantService
    {
        private readonly Service1Client _client;

        public EtudiantService(Service1Client client)
        {
            _client = client;
        }

        public EtudiantService()
        {
            _client = new Service1Client();
        }

        public async Task<Etudiant> GetEtudiantByIdAsync(int id)
        {
            return await _client.GetEtudiantByIdAsync(id);
        }

        public async Task<IEnumerable<Etudiant>> GetAllEtudiantsAsync()
        {
            return await _client.GetAllEtudiantsAsync();
        }

        public async Task AddEtudiantAsync(Etudiant etudiant)
        {
            await _client.AddEtudiantAsync(etudiant);
        }

        public async Task UpdateEtudiantAsync(Etudiant etudiant)
        {
            await _client.UpdateEtudiantAsync(etudiant);
        }

        public async Task DeleteEtudiantAsync(int id)
        {
            await _client.DeleteEtudiantAsync(id);
        }
    }
}
