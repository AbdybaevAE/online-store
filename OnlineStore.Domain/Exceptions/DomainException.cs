namespace OnlineStore.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string? message) : base(message) { }
        public DomainException() : base() { }
    }
}
