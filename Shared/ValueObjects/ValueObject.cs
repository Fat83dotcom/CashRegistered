using FluentValidation;
using Shared.Exceptions;

namespace Shared.ValueObjects;

public abstract class ValueObject
{
    public bool IsValid { get; private set; }
    public IReadOnlyCollection<string> Errors => _errors;
    private readonly List<string> _errors = new();

    protected void Validate<T>(
        T model,
        AbstractValidator<T> validator,
        Func<List<string>,
            BaseException> exceptionFactory
    )
    {
        var result = validator.Validate(model);

        if (result.IsValid) return;
        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        throw exceptionFactory(errors);
    }
}