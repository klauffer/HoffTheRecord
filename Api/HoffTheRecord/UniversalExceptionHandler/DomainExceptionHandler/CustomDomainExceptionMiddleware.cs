using API.UniversalExceptionHandler.ValidationExceptionHandler;
using Domain;
using System.Text.Json;

namespace API.UniversalExceptionHandler.DomainExceptionHandler
{
    public class CustomDomainExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomDomainExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException domainException)
            {
                await HandleValidationExceptionAsync(context, domainException);
            }

        }

        private async Task HandleValidationExceptionAsync(HttpContext context, DomainException domainException)
        {
            string serializedResponse = SerializeErrors(domainException);
            await SetResponse(context, serializedResponse);
        }

        private static string SerializeErrors(DomainException domainException)
        {
            var httpDomainErrorResponse = new HttpDomainErrorResponse() { Message = domainException.Message};
            var serializedResponse = JsonSerializer.Serialize(httpDomainErrorResponse);
            return serializedResponse;
        }

        private static async Task SetResponse(HttpContext context, string serializedResponse)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(serializedResponse);
        }


    }
    public static class CustomDomainExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomDomainExceptionMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomDomainExceptionMiddleware>();
        }
    }
}
