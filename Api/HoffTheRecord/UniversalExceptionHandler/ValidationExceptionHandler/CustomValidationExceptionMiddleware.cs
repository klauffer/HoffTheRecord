using Domain;
using FluentValidation;
using System.Text.Json;

namespace API.UniversalExceptionHandler.ValidationExceptionHandler
{
    public class CustomValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException validationException)
            {
                await HandleValidationExceptionAsync(context, validationException);
            }
        }

        private async Task HandleValidationExceptionAsync(HttpContext context, ValidationException validationException)
        {
            string serializedResponse = SerializeErrors(validationException);
            await SetResponse(context, serializedResponse);
        }

        private static string SerializeErrors(ValidationException validationException)
        {
            var httpValidationErrors = validationException.Errors.Select(error =>
                            new HttpValidationError(error.PropertyName, error.ErrorMessage));
            var httpValidationErrorResponse = new HttpValidationErrorResponse(httpValidationErrors);
            var serializedResponse = JsonSerializer.Serialize(httpValidationErrorResponse);
            return serializedResponse;
        }

        private static async Task SetResponse(HttpContext context, string serializedResponse)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(serializedResponse);
        }


    }
    public static class CustomValidationExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomValidationExceptionMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomValidationExceptionMiddleware>();
        }
    }
}
