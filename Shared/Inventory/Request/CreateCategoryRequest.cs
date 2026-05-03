namespace Shared.Inventory.Request;

public class CreateCategoryRequest
{
    public string Name { get; set; }

    public int? ParentCategoryId { get; set; }
}