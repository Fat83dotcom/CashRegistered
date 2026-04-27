namespace Shared.Inventory.Request;

public class CreateUnitOfMeasureRequest
{
    public string Code { get; set; }

    public string Name { get; set; }

    public bool AllowDecimals { get; set; }
}