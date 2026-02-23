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
} 