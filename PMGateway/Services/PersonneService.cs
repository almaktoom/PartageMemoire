using ServiceMetier;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMGateway.Services
{
    public interface IPersonneService
    {
        Task<Personne> GetPersonneByIdAsync(int id);
        Task<IEnumerable<Personne>> GetAllPersonnesAsync();
        Task AddPersonneAsync(Personne personne);
        Task UpdatePersonneAsync(Personne personne);
        Task DeletePersonneAsync(int id);
        Task<bool> ValidatePersonneAsync(string email, string password);
        Task RegisterPersonneAsync(Personne newPersonne);
    }

    public class PersonneService : IPersonneService
    {
        private readonly Service1Client _wcfClient;

        public PersonneService(Service1Client wcfClient)
        {
            _wcfClient = wcfClient;
        }

        public async Task<Personne> GetPersonneByIdAsync(int id)
        {
            return await _wcfClient.GetPersonneByIdAsync(id);
        }

        public async Task<IEnumerable<Personne>> GetAllPersonnesAsync()
        {
            return await _wcfClient.GetAllPersonnesAsync();
        }

        public async Task AddPersonneAsync(Personne personne)
        {
            await _wcfClient.AddPersonneAsync(personne);
        }

        public async Task UpdatePersonneAsync(Personne personne)
        {
            await _wcfClient.UpdatePersonneAsync(personne);
        }

        public async Task DeletePersonneAsync(int id)
        {
            await _wcfClient.DeletePersonneAsync(id);
        }

        public async Task<bool> ValidatePersonneAsync(string email, string password)
        {
            try
            {
                return await _wcfClient.ValidatePersonneAsync(email, password);
            }
            catch (Exception ex)
            {
                // Gérer l'exception (logger, rethrow, etc.)
                throw new Exception("Erreur lors de la validation de la personne", ex);
            }
        }


        public async Task RegisterPersonneAsync(Personne newPersonne)
        {
            await _wcfClient.RegisterPersonneAsync(newPersonne);
        }
    }
}
