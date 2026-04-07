using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class StockBalance : BaseEntity
{
    public StockBalance(int productId, int warehouseId, decimal availableQuantity = 0, decimal reservedQuantity = 0)
    {
        ProductId = productId;
        WarehouseId = warehouseId;
        AvailableQuantity = availableQuantity;
        ReservedQuantity = reservedQuantity;
    }

    protected StockBalance() { }

    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; }
    public decimal AvailableQuantity { get; set; }
    public decimal ReservedQuantity { get; set; }
    public decimal TotalQuantity => AvailableQuantity + ReservedQuantity;
}
