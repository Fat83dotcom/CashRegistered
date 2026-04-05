using System.Linq.Expressions;
using Domain.Identity.Entities;
using Domain.Financial.Entities;
using Shared.Abstractions;
using Shared.Identity.Response;
using Shared.Security.Response;
using Shared.Financial.Response;

namespace Domain.Financial.Repositories;

public interface ICashFlowRepository : IRepository<CashFlow>
{
    
}