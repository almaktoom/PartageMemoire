using ServiceMetier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMGateway.Services
{
    public interface IMemoireService
    {
        Task<Memoire> GetMemoireByIdAsync(int id);
        Task<IEnumerable<Memoire>> GetAllMemoiresAsync();
        Task AddMemoireAsync(Memoire memoire);
        Task UpdateMemoireAsync(Memoire memoire);
        Task DeleteMemoireAsync(int id);
    }

    public class MemoireService : IMemoireService
    {
        private readonly Service1Client _client;

        public MemoireService(Service1Client client)
        {
            _client = client;
        }

        public async Task<Memoire> GetMemoireByIdAsync(int id)
        {
            return await _client.GetMemoireByIdAsync(id);
        }

        public async Task<IEnumerable<Memoire>> GetAllMemoiresAsync()
        {
            return await _client.GetAllMemoiresAsync();
        }

        public async Task AddMemoireAsync(Memoire memoire)
        {
            await _client.AddMemoireAsync(memoire);
        }

        public async Task UpdateMemoireAsync(Memoire memoire)
        {
            await _client.UpdateMemoireAsync(memoire);
        }

        public async Task DeleteMemoireAsync(int id)
        {
            await _client.DeleteMemoireAsync(id);
        }
    }
}
