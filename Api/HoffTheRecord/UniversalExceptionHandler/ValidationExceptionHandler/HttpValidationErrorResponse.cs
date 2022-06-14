namespace API.UniversalExceptionHandler.ValidationExceptionHandler
{
    public class HttpValidationErrorResponse
    {
        public IEnumerable<HttpValidationError> HttpValidationErrors { get; set; }
    }
}
