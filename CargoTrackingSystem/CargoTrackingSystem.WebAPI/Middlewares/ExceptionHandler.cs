using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using TS.Result;

namespace CargoTrackingSystem.WebAPI.Middlewares;

public sealed class ExceptionHandler
{
    private readonly RequestDelegate _next;

    public ExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        if (exception is ValidationException validationException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            var errorFields = validationException.Errors.Select(e => e.PropertyName).ToList();
            var errorResult = Result<string>.Failure(StatusCodes.Status403Forbidden, errorFields);
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResult));
            return;
        }

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var result = Result<string>.Failure(exception.Message);
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(result));
    }
}
