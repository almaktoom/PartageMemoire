using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMGateway.Entities;
using PMGateway.JwtFeatures;
using System.IdentityModel.Tokens.Jwt;

namespace PMGateway.Controllers
{
    /*public class AccountsController : ControllerBase
    {
        private readonly UserManager<LoginRequest> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        public AccountsController(UserManager<LoginRequest> userManager, IMapper mapper, JwtHandler
        jwtHandler)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user,
            userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto
                {
                    ErrorMessage = "Invalid Authentication"
                });
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }
    }*/
}
