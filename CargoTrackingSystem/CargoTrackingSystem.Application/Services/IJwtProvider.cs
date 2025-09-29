using CargoTrackingSystem.Application.Features.Auth.Login;
using CargoTrackingSystem.Domain.Entities;

namespace CargoTrackingSystem.Application.Services;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateToken(AppUser user);
}
