namespace Shared.Inventory.Request;

public class CreateTagRequest
{
    public string Name { get; set; }

    public string? ColorHex { get; set; }
}