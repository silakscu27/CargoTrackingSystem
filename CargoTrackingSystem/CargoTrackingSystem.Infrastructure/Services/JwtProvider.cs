using CargoTrackingSystem.Application.Features.Auth.Login;
using CargoTrackingSystem.Application.Services;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CargoTrackingSystem.Infrastructure.Services;

internal class JwtProvider(
    UserManager<AppUser> userManager,
    IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    public async Task<LoginCommandResponse> CreateToken(AppUser user)
    {
        // Add user information as a claim
        List<Claim> claims = new()
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("Name", user.FullName),
            new Claim("Email", user.Email ?? ""),
            new Claim("UserName", user.UserName ?? "")
        };

        DateTime expires = DateTime.UtcNow.AddMonths(1);

        // Create signing credentials from secret key
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

        // Create JWT token
        JwtSecurityToken jwtSecurityToken = new(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: signingCredentials);

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        // Refresh token
        string refreshToken = Guid.NewGuid().ToString();
        DateTime refreshTokenExpires = expires.AddHours(1);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = refreshTokenExpires;

        await userManager.UpdateAsync(user);

        return new LoginCommandResponse(token, refreshToken, refreshTokenExpires);
    }
}
