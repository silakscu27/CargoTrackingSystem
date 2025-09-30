using CargoTrackingSystem.Domain.Abstractions;
using CargoTrackingSystem.Domain.Entities;
using CargoTrackingSystem.Infrastructure.Context;
using CargoTrackingSystem.Infrastructure.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Scrutor;
using System.Reflection;

namespace CargoTrackingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // UnitOfWork
            services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

            // Identity
            services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer();

            services.AddAuthorization();

            services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
            services.AddSingleton<IPostConfigureOptions<JwtBearerOptions>, JwtTokenOptionsSetup>();

            // Auto register Repositories / Services (Scrutor)
            services.Scan(scan => scan
                .FromAssemblies(Assembly.GetExecutingAssembly())
                .AddClasses()
                .AsMatchingInterface()
                .WithScopedLifetime()
            );

            // Health Checks
            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            return services;
        }
    }
}