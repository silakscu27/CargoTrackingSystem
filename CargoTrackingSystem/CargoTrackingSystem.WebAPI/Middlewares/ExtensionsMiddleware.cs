using CargoTrackingSystem.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CargoTrackingSystem.WebAPI.Middlewares
{
    public static class ExtensionsMiddleware
    {
        public static void CreateFirstUser(WebApplication app)
        {
            using (var scoped = app.Services.CreateScope())
            {
                var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                // 1️- Admin User
                if (!userManager.Users.Any(p => p.UserName == "admin"))
                {
                    AppUser admin = new()
                    {
                        UserName = "admin",
                        Email = "admin@admin.com",
                        FirstName = "Sıla",
                        LastName = "Kuscu",
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(admin, "admin123").Wait();
                }

                // 2️- Manager User
                if (!userManager.Users.Any(p => p.UserName == "manager"))
                {
                    AppUser manager = new()
                    {
                        UserName = "manager",
                        Email = "manager@cargo.com",
                        FirstName = "Ahmet",
                        LastName = "Yılmaz",
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(manager, "manager123").Wait();
                }

                // 3️- Customer User
                if (!userManager.Users.Any(p => p.UserName == "customer"))
                {
                    AppUser customer = new()
                    {
                        UserName = "customer",
                        Email = "customer@cargo.com",
                        FirstName = "Zeynep",
                        LastName = "Demir",
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(customer, "customer123").Wait();
                }
            }
        }
    }
}
