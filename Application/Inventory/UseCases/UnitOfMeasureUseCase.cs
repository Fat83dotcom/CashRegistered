using Application.Inventory.Interfaces;
using Domain.Inventory.Entities;
using Domain.Inventory.Repositories;
using Shared.Abstractions;
using Shared.Inventory.Request;
using Shared.Inventory.Response;
using Shared.Notifications;
using Shared.Request;
using Shared.Response;

namespace Application.Inventory.UseCases;

public class UnitOfMeasureUseCase(
    IUnitOfMeasureRepository repository,
    IUnitOfWork unitOfWork,
    NotificationContext notificationContext) : IUnitOfMeasureUseCase
{
    public async Task<CreateResponse> CreateUnitOfMeasure(CreateUnitOfMeasureRequest request)
    {
        var uom = new UnitOfMeasure(
            request.Code,
            request.Name,
            request.AllowDecimals
        );  

       await uom.CodeExists(repository, request.Code);
        
        if (uom.IsInvalid)
        {
            notificationContext.AddNotifications(uom.Notifications);
            return new CreateResponse
            {
                Id = 0
            };
        }
        
        await repository.CreateAsync(uom);
        await unitOfWork.CommitAsync();
        
        return new CreateResponse
        {
            Id = uom.Id
        };
    }

    public async Task<IEnumerable<GetSearchUnitsResponse>> GetAllUnits()
    {
        var result = await repository.FindAsync(u => true);
        return result.Select(u =>
            new GetSearchUnitsResponse
            {
                Id = u.Id,
                Code = u.Code,
                Name = u.Name,
                AllowDecimals = u.AllowDecimals
            }
        );
    }

    public async Task<PagedResponse<GetSearchUnitsResponse>> SearchUnits(SearchUnitOfMeasureRequest request)
    {
        var pagedUoms = await repository.SearchAsync(request);

        return new PagedResponse<GetSearchUnitsResponse>
        {
            Items = pagedUoms.Items.Select(u => new GetSearchUnitsResponse
            {
                Id = u.Id,
                Code = u.Code,
                Name = u.Name,
                AllowDecimals = u.AllowDecimals
            }),
            Page = pagedUoms.Page,
            PageSize = pagedUoms.PageSize,
            TotalCount = pagedUoms.TotalCount
        };
    }
}