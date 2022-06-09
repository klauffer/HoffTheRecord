using FluentValidation;
using System.Text.Json;

namespace API.UniversalExceptionHandler
{
    public class CustomExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlingMiddleware(RequestDelegate next)
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
                await HandleExceptionAsync(context, validationException);
            }
            
        }

        private async Task HandleExceptionAsync(HttpContext context, ValidationException validationException)
        {
            string serializedResponse = SerializeErrors(validationException);
            await SetResponse(context, serializedResponse);
        }

        private static async Task SetResponse(HttpContext context, string serializedResponse)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(serializedResponse);
        }

        private static string SerializeErrors(ValidationException validationException)
        {
            var httpValidationErrors = validationException.Errors.Select(error =>
                            new HttpValidationError() { PropertyName = error.PropertyName, Message = error.ErrorMessage });
            var httpValidationErrorResponse = new HttpValidationErrorResponse() { HttpValidationErrors = httpValidationErrors };
            var serializedResponse = JsonSerializer.Serialize(httpValidationErrorResponse);
            return serializedResponse;
        }
    }
    public static class CustomExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandlingMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlingMiddleware>();
        }
    }
}
