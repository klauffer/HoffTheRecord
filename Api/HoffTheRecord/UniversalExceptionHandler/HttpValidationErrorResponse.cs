using System.Text.Json;

namespace API.UniversalExceptionHandler
{
    public class HttpValidationErrorResponse
    {
        public IEnumerable<HttpValidationError> HttpValidationErrors { get; set; }
    }
}
