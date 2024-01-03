using BlazorFinance.Shared.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Repositories
{
    public interface IIncomeRepository
    {
        public Task<BsonValue> CreateIncomeAsync(Income income);

        public Task<Income> ReadIncomeAsync(int id);

        public Task<List<Income>> ReadIncomeListAsync();

        public Task<List<Income>> ReadIncomeListAsync(Expression<Func<Income, bool>> predicate);

        public Task<bool> UpdateIncomeAsync(Income income);

        public Task<bool> DeleteIncomeAsync(BsonValue id);
    }
}
