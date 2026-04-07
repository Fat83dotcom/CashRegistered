using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class UomConversion : BaseEntity
{
    public UomConversion(int fromUomId, int toUomId, decimal multiplier, int? productId = null)
    {
        FromUomId = fromUomId;
        ToUomId = toUomId;
        Multiplier = multiplier;
        ProductId = productId;
    }

    protected UomConversion() { }

    public int FromUomId { get; set; }
    public UnitOfMeasure FromUom { get; set; }
    public int ToUomId { get; set; }
    public UnitOfMeasure ToUom { get; set; }
    public decimal Multiplier { get; set; }
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
}
