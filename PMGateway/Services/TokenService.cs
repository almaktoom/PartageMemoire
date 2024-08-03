using ServiceMetier;

namespace PMGateway.Services
{

    public interface ITokenService
    {
        Task<Token> GetTokenByIdAsync(int id);
        Task<IEnumerable<Token>> GetAllTokensAsync();
        Task AddTokenAsync(Token token);
        Task UpdateTokenAsync(Token token);
        Task DeleteTokenAsync(int id);
        Task<JwtSettings> GetJwtSettingsByIdAsync(int id);
        Task<IEnumerable<JwtSettings>> GetAllJwtSettingsAsync();
        Task AddJwtSettingsAsync(JwtSettings jwtSettings);
        Task UpdateJwtSettingsAsync(JwtSettings jwtSettings);
        Task DeleteJwtSettingsAsync(int id);
    }

    public class TokenService : ITokenService
    {
        private readonly Service1Client _wcfClient;

        public TokenService(Service1Client wcfClient)
        {
            _wcfClient = wcfClient;
        }

        public async Task<Token> GetTokenByIdAsync(int id)
        {
            return await _wcfClient.GetTokenByIdAsync(id);
        }

        public async Task<IEnumerable<Token>> GetAllTokensAsync()
        {
            return await _wcfClient.GetAllTokensAsync();
        }

        public async Task AddTokenAsync(Token token)
        {
            await _wcfClient.AddTokenAsync(token);
        }

        public async Task UpdateTokenAsync(Token token)
        {
            await _wcfClient.UpdateTokenAsync(token);
        }

        public async Task DeleteTokenAsync(int id)
        {
            await _wcfClient.DeleteTokenAsync(id);
        }

        public async Task<JwtSettings> GetJwtSettingsByIdAsync(int id)
        {
            return await _wcfClient.GetJwtSettingsByIdAsync(id);
        }

        public async Task<IEnumerable<JwtSettings>> GetAllJwtSettingsAsync()
        {
            return await _wcfClient.GetAllJwtSettingsAsync();
        }

        public async Task AddJwtSettingsAsync(JwtSettings jwtSettings)
        {
            await _wcfClient.AddJwtSettingsAsync(jwtSettings);
        }

        public async Task UpdateJwtSettingsAsync(JwtSettings jwtSettings)
        {
            await _wcfClient.UpdateJwtSettingsAsync(jwtSettings);
        }

        public async Task DeleteJwtSettingsAsync(int id)
        {
            await _wcfClient.DeleteJwtSettingsAsync(id);
        }
    }
}
