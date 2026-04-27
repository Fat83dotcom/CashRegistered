using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class Product : BaseEntity
{
    public Product(
        string sku,
        string name,
        int categoryId,
        int baseUomId,
        string? description = null,
        string? ncmCode = null,
        decimal averageCost = 0
    )
    {
        Sku = sku;
        Name = name;
        CategoryId = categoryId;
        BaseUomId = baseUomId;
        Description = description;
        NcmCode = ncmCode;
        AverageCost = averageCost;
    }

    protected Product() { }

    public string Sku { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public string? NcmCode { get; set; }
    
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
    
    public int BaseUomId { get; set; }
    
    public UnitOfMeasure BaseUom { get; set; }
    
    public decimal AverageCost { get; set; }

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    
    public ICollection<StockBalance> StockBalances { get; set; } = new List<StockBalance>();
}
