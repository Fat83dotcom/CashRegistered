namespace Shared.Exceptions;

public class DomainException : Exception
{
    public IReadOnlyCollection<string> Errors { get; }

    public DomainException(string message) : base(message) 
    { 
        Errors = new List<string>();
    }

    public DomainException(List<string> errors) : base("Um ou mais erros de validação de domínio ocorreram.")
    {
        Errors = errors.AsReadOnly();
    }

    public DomainException(string message, List<string> errors) : base(message)
    {
        Errors = errors.AsReadOnly();
    }
}
