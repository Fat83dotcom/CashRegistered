using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class UnitOfMeasure : BaseEntity
{
    public UnitOfMeasure(string code, string name, bool allowDecimals = false)
    {
        Code = code;
        Name = name;
        AllowDecimals = allowDecimals;
    }

    protected UnitOfMeasure() { }

    public string Code { get; set; }
    public string Name { get; set; }
    public bool AllowDecimals { get; set; }
}
