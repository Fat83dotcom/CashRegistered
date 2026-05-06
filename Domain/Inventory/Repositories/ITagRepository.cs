using Domain.Inventory.Entities;
using Shared.Abstractions;
using Shared.Inventory.Request;
using Shared.Response;

namespace Domain.Inventory.Repositories;

public interface ITagRepository : IRepository<Tag>
{
    Task<PagedResponse<Tag>> SearchAsync(SearchTagRequest request);
}