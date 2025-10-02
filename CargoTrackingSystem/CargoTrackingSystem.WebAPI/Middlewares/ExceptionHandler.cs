using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using TS.Result;

namespace CargoTrackingSystem.WebAPI.Middlewares
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            Result<string> errorResult;

            httpContext.Response.ContentType = "application/json";

            // If there is a validation error return 403.
            if (exception is ValidationException validationException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

                var errorFields = validationException.Errors.Select(e => e.PropertyName).ToList();

                errorResult = Result<string>.Failure(StatusCodes.Status403Forbidden, errorFields);

                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResult), cancellationToken);
                return true;
            }

            // other errors 500
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            errorResult = Result<string>.Failure(exception.Message);

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResult), cancellationToken);

            return true;
        }
    }
}
