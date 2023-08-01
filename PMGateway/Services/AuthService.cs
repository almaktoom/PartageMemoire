using Microsoft.IdentityModel.Tokens;
using ServiceMetier;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PMGateway.Services
{

    public interface IAuthService
    {
        Task<Token> AuthenticateAsync(string email, string password);
        Task RegisterAsync(Personne newPersonne);
    }


    public class AuthService : IAuthService
    {
        private readonly IPersonneService _personneService;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IPersonneService personneService, ITokenService tokenService, JwtSettings jwtSettings)
        {
            _personneService = personneService;
            _tokenService = tokenService;
            _jwtSettings = jwtSettings; // Ajoutez cette ligne
        }

        public async Task<Token> AuthenticateAsync(string email, string password)
        {
            // Valider la personne
            var isValid = await _personneService.ValidatePersonneAsync(email, password);
            if (!isValid)
            {
                throw new UnauthorizedAccessException("Email ou mot de passe invalide.");
            }

            // Créer les claims pour le token
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Email, email),
        // Ajoutez d'autres claims si nécessaire
    };

            // Générer le token
            var accessToken = GenerateAccessToken(claims);
            var refreshToken = GenerateRefreshToken();

            var token = new Token
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            // Ajoutez le token à la base de données si nécessaire
            await _tokenService.AddTokenAsync(token);

            return token;
        }


        public async Task RegisterAsync(Personne newPersonne)
        {
            // Enregistrer la nouvelle personne
            await _personneService.RegisterPersonneAsync(newPersonne);
        }

        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }

}
