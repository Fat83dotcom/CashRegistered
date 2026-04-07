using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class Category : BaseEntity
{
    public Category(string name, int? parentCategoryId = null)
    {
        Name = name;
        ParentCategoryId = parentCategoryId;
    }

    protected Category() { }

    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Category> SubCategories { get; set; } = new List<Category>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
