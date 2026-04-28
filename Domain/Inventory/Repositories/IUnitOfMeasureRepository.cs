using Domain.Inventory.Entities;
using Shared.Abstractions;
using Shared.Inventory.Request;
using Shared.Response;

namespace Domain.Inventory.Repositories;

public interface IUnitOfMeasureRepository : IRepository<UnitOfMeasure>
{
    Task<PagedResponse<UnitOfMeasure>> SearchAsync(SearchUnitOfMeasureRequest request);
    
    
}