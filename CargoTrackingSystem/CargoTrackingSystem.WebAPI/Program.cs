using CargoTrackingSystem.Infrastructure;
using CargoTrackingSystem.WebAPI.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// --- Infrastructure registration ---
builder.Services.AddInfrastructure(builder.Configuration);

// --- MediatR registration ---
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        Assembly.GetExecutingAssembly(), // WebAPI
        typeof(CargoTrackingSystem.Application.Features.Auth.Login.LoginCommand).Assembly // Application
    );
});

// --- AutoMapper global registration ---
builder.Services.AddAutoMapper(cfg =>
{
}, typeof(CargoTrackingSystem.Application.Mapping.MappingProfile).Assembly);


// --- Controllers, Swagger, etc. ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- Custom middlewares ---
ExtensionsMiddleware.CreateFirstUser(app);
app.UseMiddleware<ExceptionHandler>();

// --- Swagger & pipeline ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
