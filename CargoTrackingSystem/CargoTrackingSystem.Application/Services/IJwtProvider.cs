using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Application.Features.Auth.Login;

namespace CargoTrackingSystem.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}