using FluentValidation;
using Shared.Exceptions;

namespace Shared.ValueObjects;

public class ValueObject
{
    public bool IsValid { get; private set; }
    public IReadOnlyCollection<string> Errors => _errors;
    private readonly List<string> _errors = new();

    protected void Validate<T>(T model, AbstractValidator<T> validator)
    {
        var result = validator.Validate(model);
        
        if (!result.IsValid)
        {
            // Opção 1: Lançar exceção de domínio (Recomendado para Falhas Críticas)
            throw new DomainException(result.Errors.Select(x => x.ErrorMessage).ToList());
        }
    }
}