using Domain.Inventory.Enums;
using Domain.Identity.Entities;
using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class InventoryTransaction : BaseEntity
{
    public InventoryTransaction(
        int userId,
        InventoryTransactionType type,
        string? referenceDocument = null
    )
    {
        DateTime = DateTime.UtcNow;
        UserId = userId;
        TransactionType = type;
        Status = InventoryTransactionStatus.Draft;
        ReferenceDocument = referenceDocument;
    }

    protected InventoryTransaction() { }

    public DateTime DateTime { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public InventoryTransactionType TransactionType { get; set; }
    
    public InventoryTransactionStatus Status { get; set; }
    
    public string? ReferenceDocument { get; set; }
    
    public ICollection<InventoryTransactionItem> Items { get; set; } = new List<InventoryTransactionItem>();
}
