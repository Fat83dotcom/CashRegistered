using Domain.Inventory.Entities;
using Shared.Abstractions;
using Shared.Inventory.Request;
using Shared.Response;

namespace Domain.Inventory.Repositories;

public interface IUomConversionRepository : IRepository<UomConversion>
{
    Task<PagedResponse<UomConversion>> SearchAsync(SearchUomConversionRequest request);
}