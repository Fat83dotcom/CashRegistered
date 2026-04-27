using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class InventoryTransactionItem : BaseEntity
{
    public InventoryTransactionItem(
        int transactionId,
        int productId,
        int uomId,
        decimal transactionQuantity,
        decimal baseQuantity,
        int? sourceWarehouseId = null,
        int? destinationWarehouseId = null
    )
    {
        TransactionId = transactionId;
        ProductId = productId;
        UomId = uomId;
        TransactionQuantity = transactionQuantity;
        BaseQuantity = baseQuantity;
        SourceWarehouseId = sourceWarehouseId;
        DestinationWarehouseId = destinationWarehouseId;
    }

    protected InventoryTransactionItem() { }

    public int TransactionId { get; set; }
    
    public InventoryTransaction Transaction { get; set; }
    
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    public int? SourceWarehouseId { get; set; }
    
    public Warehouse? SourceWarehouse { get; set; }
    
    public int? DestinationWarehouseId { get; set; }
    
    public Warehouse? DestinationWarehouse { get; set; }
    
    public int UomId { get; set; }
    
    public UnitOfMeasure Uom { get; set; }
    
    public decimal TransactionQuantity { get; set; }
    
    public decimal BaseQuantity { get; set; }
}
