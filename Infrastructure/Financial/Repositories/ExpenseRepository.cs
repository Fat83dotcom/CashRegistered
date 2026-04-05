using System.Linq.Expressions;
using Domain.Financial.Entities;
using Domain.Financial.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Financial.Repositories;

public class ExpenseRepository(CashRegisterDbContext context) : IExpenseRepository
{
    public async Task CreateAsync(Expense entity)
    {
        await context.Expenses.AddAsync(entity);
    }

    public Task<Expense?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Expense>> FindAsync(Expression<Func<Expense, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Update(Expense entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Expense entity)
    {
        throw new NotImplementedException();
    }
}