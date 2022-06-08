using FluentValidation;

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
                validationException.Errors.Select(error => new HttpValidationErrorResponse(error.PropertyName, error.ErrorMessage));
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            
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
