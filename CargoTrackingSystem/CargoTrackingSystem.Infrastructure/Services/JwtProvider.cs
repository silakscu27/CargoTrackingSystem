using CargoTrackingSystem.Application.Services;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Application.Features.Auth.Login;
using Microsoft.Extensions.Options;
using CargoTrackingSystem.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CargoTrackingSystem.Infrastructure.Services
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<AppUser> _userManager;

        public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
        }

        public async Task<LoginCommandResponse> CreateToken(AppUser user)
        {
            // Claim'leri oluştur
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Rolleri ekle
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Token oluştur
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddHours(1);
            var refreshTokenExpires = DateTime.UtcNow.AddDays(7); // Refresh token 7 gün geçerli

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginCommandResponse(
                Token: tokenString,
                RefreshToken: Guid.NewGuid().ToString(),
                RefreshTokenExpires: refreshTokenExpires
            );
        }
    }
}