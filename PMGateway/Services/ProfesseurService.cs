using ServiceMetier;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMGateway.Services
{
    public interface IProfesseurService
    {
        Task<Professeur> GetProfesseurByIdAsync(int id);
        Task<IEnumerable<Professeur>> GetAllProfesseursAsync();
        Task AddProfesseurAsync(Professeur professeur);
        Task UpdateProfesseurAsync(Professeur professeur);
        Task DeleteProfesseurAsync(int id);
    }

    public class ProfesseurService : IProfesseurService
    {
        private readonly Service1Client _client;

        public ProfesseurService(Service1Client client)
        {
            _client = client;
        }

        public async Task<Professeur> GetProfesseurByIdAsync(int id)
        {
            return await _client.GetProfesseurByIdAsync(id);
        }

        public async Task<IEnumerable<Professeur>> GetAllProfesseursAsync()
        {
            return await _client.GetAllProfesseursAsync();
        }

        public async Task AddProfesseurAsync(Professeur professeur)
        {
            await _client.AddProfesseurAsync(professeur);
        }

        public async Task UpdateProfesseurAsync(Professeur professeur)
        {
            await _client.UpdateProfesseurAsync(professeur);
        }

        public async Task DeleteProfesseurAsync(int id)
        {
            await _client.DeleteProfesseurAsync(id);
        }
    }
}
