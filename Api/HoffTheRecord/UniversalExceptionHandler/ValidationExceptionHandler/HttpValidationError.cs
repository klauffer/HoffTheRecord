namespace API.UniversalExceptionHandler.ValidationExceptionHandler
{
    public class HttpValidationError
    {
        public HttpValidationError(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }

        public string PropertyName { get; }
        public string Message { get; }
    }
}
