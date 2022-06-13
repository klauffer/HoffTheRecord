namespace Domain.UniversalDateTime
{
    public class LocalMachineDateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
