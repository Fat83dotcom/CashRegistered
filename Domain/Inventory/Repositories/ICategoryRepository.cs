using Domain.Inventory.Entities;
using Shared.Abstractions;
using Shared.Inventory.Request;
using Shared.Response;

namespace Domain.Inventory.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<PagedResponse<Category>> SearchAsync(SearchCategoryRequest request);
}