namespace Shared.Inventory.Request;

public class CreateProductRequest
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? NcmCode  { get; set; }

    public int CategoryId { get; set; }

    public int BaseUom { get; set; }

    public decimal AverageCost { get; set; }
}