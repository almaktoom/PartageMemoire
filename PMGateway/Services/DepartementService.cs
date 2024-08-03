using ServiceMetier; // Assurez-vous d'importer le bon namespace

namespace PMGateway.Services
{

    public interface IDepartementService
    {
        Task<Departement> GetDepartementByIdAsync(int id);
        Task<Departement[]> GetAllDepartementsAsync();
        Task AddDepartementAsync(Departement departement);
        Task UpdateDepartementAsync(Departement departement);
        Task DeleteDepartementAsync(int id);
    }

    public class DepartementService : IDepartementService
    {
        private readonly Service1Client _client;

        public DepartementService(Service1Client client)
        {
            _client = client;
        }

        public async Task<Departement> GetDepartementByIdAsync(int id)
        {
            return await _client.GetDepartementByIdAsync(id);
        }

        public async Task<Departement[]> GetAllDepartementsAsync()
        {
            return await _client.GetAllDepartementsAsync();
        }

        public async Task AddDepartementAsync(Departement departement)
        {
            await _client.AddDepartementAsync(departement);
        }

        public async Task UpdateDepartementAsync(Departement departement)
        {
            await _client.UpdateDepartementAsync(departement);
        }

        public async Task DeleteDepartementAsync(int id)
        {
            await _client.DeleteDepartementAsync(id);
        }
    }

}
