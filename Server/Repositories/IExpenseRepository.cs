using BlazorFinance.Shared.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Repositories
{
    public interface IExpenseRepository
    {
        public Task<BsonValue> CreateExpenseAsync(Expense expense);

        public Task<Expense> ReadExpenseAsync(int id);

        public Task<List<Expense>> ReadExpenseListAsync();

        public Task<List<Expense>> ReadExpenseListAsync(Expression<Func<Expense, bool>> predicate);

        public Task<bool> UpdateExpenseAsync(Expense expense);

        public Task<bool> DeleteExpenseAsync(BsonValue id);
    }
}
