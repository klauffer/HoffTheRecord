namespace API.UniversalExceptionHandler.ValidationExceptionHandler
{
    public class HttpValidationErrorResponse
    {
        public HttpValidationErrorResponse(IEnumerable<HttpValidationError> httpValidationErrors)
        {
            HttpValidationErrors = httpValidationErrors;
        }

        public IEnumerable<HttpValidationError> HttpValidationErrors { get; }
    }
}
