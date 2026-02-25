using FluentValidation;
using Shared.Exceptions;

namespace Shared.Abstractions;

public abstract class BaseEntity
{
    public int Id { get; protected set; }
    
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    public bool IsActive { get; private set; } = true;

    // Método para atualizar o timestamp automaticamente
    protected void RegisterUpdate()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        RegisterUpdate();
    }
    
    public void Activate()
    {
        IsActive = true;
        RegisterUpdate();
    }
    
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