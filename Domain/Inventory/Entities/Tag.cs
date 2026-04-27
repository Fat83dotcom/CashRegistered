using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class Tag : BaseEntity
{
    public Tag(string name, string? hexColor = null)
    {
        Name = name;
        HexColor = hexColor;
    }

    protected Tag() { }

    public string Name { get; set; }
    
    public string? HexColor { get; set; }
    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
