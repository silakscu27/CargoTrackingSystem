using CargoTrackingSystem.Application.Services;
using CargoTrackingSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace CargoTrackingSystem.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.Users
            .FirstOrDefaultAsync(p =>
                p.UserName == request.EmailOrUserName ||
                p.Email == request.EmailOrUserName,
                cancellationToken);

        if (user is null)
        {
            return Result<LoginCommandResponse>.Failure("Kullanıcı bulunamadı");
        }

        // Check if user is locked
        if (await userManager.IsLockedOutAsync(user))
        {
            var lockoutEnd = await userManager.GetLockoutEndDateAsync(user);
            if (lockoutEnd.HasValue)
            {
                var timeRemaining = lockoutEnd.Value - DateTime.UtcNow;
                return Result<LoginCommandResponse>.Failure($"Şifrenizi 3 defa yanlış girdiğiniz için kullanıcı {Math.Ceiling(timeRemaining.TotalMinutes)} dakika süreyle bloke edilmiştir");
            }
            return Result<LoginCommandResponse>.Failure("Kullanıcınız 3 kez yanlış şifre girdiği için 5 dakika süreyle bloke edilmiştir");
        }

        // Check if your email is verified
        if (!await userManager.IsEmailConfirmedAsync(user))
        {
            return Result<LoginCommandResponse>.Failure("Mail adresiniz onaylı değil");
        }

        // Password controll
        bool isPasswordCorrect = await userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordCorrect)
        {
            // Save the incorrect entry
            await userManager.AccessFailedAsync(user);
            return Result<LoginCommandResponse>.Failure("Şifreniz yanlış");
        }

        // Successful login - reset error counter
        await userManager.ResetAccessFailedCountAsync(user);

        // Create token
        var loginResponse = await jwtProvider.CreateToken(user);
        return Result<LoginCommandResponse>.Succeed(loginResponse);
    }
}