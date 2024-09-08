namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, int id) : base($"{message} ID: {id}")
        {
        }

        public NotFoundException(string message, string isbn) : base($"{message} ISBN: {isbn}")
        {
        }
    }
}
