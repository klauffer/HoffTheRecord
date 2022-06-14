namespace API.UniversalExceptionHandler.DomainExceptionHandler
{
    public class HttpDomainErrorResponse
    {
        public HttpDomainErrorResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
