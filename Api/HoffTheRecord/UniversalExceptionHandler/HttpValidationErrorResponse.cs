namespace API.UniversalExceptionHandler
{
    public class HttpValidationErrorResponse
    {
        public string PropertyName { get; }
        public string Message { get; }

        public HttpValidationErrorResponse(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }
    }
}
