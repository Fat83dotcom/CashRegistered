namespace Shared.Inventory.Response;

public class GetSearchUomConversionResponse
{
    public int Id { get; set; }

    public int FromUnitSymbolId { get; set; }

    public string? FromUnitSymbol { get; set; }
    
    public string? FromUnitName { get; set; }

    public int ToUnitSymbolId { get; set; }

    public string? ToUnitSymbol { get; set; }
    
    public string? ToUnitName { get; set; }

    public decimal Multiplier { get; set; }

    public int? ProductId { get; set; } = null;
    
    public string? ProductName { get; set; } = null;

    public bool IsActive { get; set; }
}