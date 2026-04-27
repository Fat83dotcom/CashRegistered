namespace Shared.Inventory.Request;

public class CreateUomConversionRequest
{
    public decimal Multiplier { get; set; }

    public int FromUomId { get; set; }

    public int ToUomId { get; set; }

    public int? ProductId { get; set; } = 0;
}