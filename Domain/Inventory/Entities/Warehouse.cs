using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class Warehouse : BaseEntity
{
    public Warehouse(string name, string type)
    {
        Name = name;
        Type = type;
    }

    protected Warehouse() { }

    public string Name { get; set; }
    public string Type { get; set; }
    public ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();
}
