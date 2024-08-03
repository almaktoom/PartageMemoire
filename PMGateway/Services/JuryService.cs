using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Services
{
    public interface IJuryService
    {
        Task<Jury> GetJuryByIdAsync(int id);
        Task<IEnumerable<Jury>> GetAllJuriesAsync();
        Task AddJuryAsync(Jury jury);
        Task UpdateJuryAsync(Jury jury);
        Task DeleteJuryAsync(int id);
    }

    public class JuryService : IJuryService
    {
        private readonly Service1Client _client;

        public JuryService(Service1Client client)
        {
            _client = client;
        }

        public async Task<Jury> GetJuryByIdAsync(int id)
        {
            return await _client.GetJuryByIdAsync(id);
        }

        public async Task<IEnumerable<Jury>> GetAllJuriesAsync()
        {
            return await _client.GetAllJuriesAsync();
        }

        public async Task AddJuryAsync(Jury jury)
        {
            await _client.AddJuryAsync(jury);
        }

        public async Task UpdateJuryAsync(Jury jury)
        {
            await _client.UpdateJuryAsync(jury);
        }

        public async Task DeleteJuryAsync(int id)
        {
            await _client.DeleteJuryAsync(id);
        }
    }
}
