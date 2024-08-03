using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMGateway.Model;
using PMGateway.Services;

using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private JwtTokenService _jwtTokenService;
    private JwtSettings _jwtSettings;
    private RefreshTokenService _refreshTokenService;
    private ApplicationDbContext _context;
    private PasswordService _passwordService;


    public AuthController(JwtTokenService jwtTokenService, JwtSettings jwtSettings,
        RefreshTokenService refreshTokenService, ApplicationDbContext context, PasswordService passwordService)
    {
        _jwtTokenService = jwtTokenService;
        _jwtSettings = jwtSettings;
        _refreshTokenService = refreshTokenService;
        _context = context;
        _passwordService = passwordService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] PMGateway.Model.RegisterRequest request)
    {
        var hashedPassword = _passwordService.HashPassword(request.Password);

        var user = new User
        {
            Username = request.Username,
            PasswordHash = hashedPassword,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok("Utilisateur créé avec succès.");
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] PMGateway.Model.LoginRequest request)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == request.Username);
        if (user == null || !_passwordService.VerifyPassword(request.Password, user.PasswordHash))
        {
            return Unauthorized("Identifiants invalides.");
        }

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, user.Username)
    };

        var accessToken = _jwtTokenService.GenerateAccessToken(claims);
        var refreshToken = _jwtTokenService.GenerateRefreshToken();

        var newRefreshToken = new RefreshToken
        {
            Token = refreshToken,
            Username = user.Username,
            ExpirationDate = DateTime.UtcNow.AddDays(7)
        };
        _refreshTokenService.AddRefreshToken(newRefreshToken);

        return Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
    }


    [HttpPost("refresh")]
    public IActionResult Refresh([FromBody] TokenRequest request)
    {
        // Récupérer le jeton d'actualisation stocké
        var storedRefreshToken = _refreshTokenService.GetStoredRefreshToken(request.RefreshToken);

        if (storedRefreshToken == null || storedRefreshToken.ExpirationDate < DateTime.UtcNow)
        {
            return Unauthorized("Jeton d'actualisation non valide ou expiré.");
        }

        // Créer de nouvelles revendications
        var claims = new[]
        {
        new Claim(ClaimTypes.Name, storedRefreshToken.Username)
    };

        // Générer de nouveaux jetons
        var newAccessToken = _jwtTokenService.GenerateAccessToken(claims);
        var newRefreshToken = _jwtTokenService.GenerateRefreshToken();

        // Mettre à jour le jeton d'actualisation stocké
        storedRefreshToken.Token = newRefreshToken;
        storedRefreshToken.ExpirationDate = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays);
        _refreshTokenService.SaveRefreshToken(storedRefreshToken);

        return Ok(new { AccessToken = newAccessToken, RefreshToken = newRefreshToken });
    }


}
