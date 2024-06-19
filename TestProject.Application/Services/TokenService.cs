using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestProject.Domain.ConfigObjects;
using TestProject.Domain.Entities;
using TestProject.Domain.Interfaces.Services;

namespace TestProject.Application.Services
{
    public class TokenService : ITokenService
    {

        private readonly UserManager<User> _userManager;
        private readonly JWTConfig JWTConfig;

        public TokenService(UserManager<User> userManager, IOptions<JWTConfig> JwtOptions)
        {
            _userManager = userManager;
            JWTConfig = JwtOptions.Value;
        }

        public async Task<string> GenerateTokenByUser(User user)
        {
            var tokenDescriptor = await GetTokenDescriptorByUser(user);

            return GenerateJwtToken(tokenDescriptor);
        }

        private async Task<SecurityTokenDescriptor> GetTokenDescriptorByUser(User user)
        {

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaimsIdentity(user),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTConfig.SecretKey ?? "")),
                                                SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddHours(JWTConfig.ExpirationHours),
                Issuer = JWTConfig.Issuer,
                Audience = JWTConfig.Audience
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            tokenDescriptor.Subject.AddClaims(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            return tokenDescriptor;
        }

        private static ClaimsIdentity GenerateClaimsIdentity(User user) => new (claims:[
                new ("UserID",user.Id.ToString() ?? ""),
                new ("Email",user.Email ?? ""),
            ]);

        private static string GenerateJwtToken(SecurityTokenDescriptor tokenDescriptor)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}