namespace Shared.Inventory.Response;

public class GetSearchUnitsResponse
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public bool AllowDecimals { get; set; }
}