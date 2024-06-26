using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Reciclagem.api.Services;
using Reciclagem.api.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Reciclagem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController()
        {
            _authService = new AuthService();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel user) 
        { 
            var authenticatedUser = _authService.Authenticate(user.Username, user.Senha);
            if (authenticatedUser == null)
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(authenticatedUser);
            return Ok(new { Token = token });
        }


        private string GenerateJwtToken(UserModel user)
        {
            byte[] secret = Encoding.ASCII.GetBytes("123456789");
            var securityKey = new SymmetricSecurityKey(secret);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Funcao),
                    new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Issuer = "fiap",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret), 
                    SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
