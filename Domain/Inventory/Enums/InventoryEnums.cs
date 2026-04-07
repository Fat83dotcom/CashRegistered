namespace Domain.Inventory.Enums;

public enum InventoryTransactionType
{
    PurchaseEntry,
    Transfer,
    RequisitionExit,
    Reversal
}

public enum InventoryTransactionStatus
{
    Draft,
    Completed,
    Cancelled
}

public enum PurchaseRequisitionStatus
{
    Open,
    Approved,
    Fulfilled,
    Cancelled
}

public enum PurchaseOrderStatus
{
    Issued,
    PartiallyReceived,
    Completed,
    Cancelled
}

public enum InternalRequisitionStatus
{
    Pending,
    Approved,
    Fulfilled,
    Rejected
}
