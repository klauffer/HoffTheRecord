using System.Globalization;

namespace Domain
{
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(string message)
            : base(message)
        {
        }

        public DomainException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
