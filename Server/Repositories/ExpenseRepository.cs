using BlazorFinance.Server.Data;
using BlazorFinance.Shared.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private IDataContext<Expense> _context;

        public ExpenseRepository(IDataContext<Expense> context) 
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Expense object
        /// </summary>
        /// <param name="Expense"></param>
        /// <returns>BsonValue</returns>
        public async Task<BsonValue> CreateExpenseAsync(Expense expense)
        {
            return await _context.Create(expense);
        }

        /// <summary>
        /// Reads a single Expense object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Expense</returns>
        public async Task<Expense> ReadExpenseAsync(int id)
        {
            return await _context.Read(id);
        }

        /// <summary>
        /// Reads a list of Expense objects matching predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List<Expense></returns>
        public async Task<List<Expense>> ReadExpenseListAsync(Expression<Func<Expense, bool>> predicate)
        {
            return await _context.Read(predicate);
        }

        /// <summary>
        /// Reads a list of (all) Expense objects
        /// </summary>
        /// <returns>List<Expense></returns>
        public async Task<List<Expense>> ReadExpenseListAsync()
        {
            return await _context.Read();
        }

        /// <summary>
        /// Updates an existing Expense object
        /// </summary>
        /// <param name="Expense"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateExpenseAsync(Expense expense)
        {
            return await _context.Update(expense);
        }

        /// <summary>
        /// Deletes an Expense object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteExpenseAsync(BsonValue id)
        {
            return await _context.Delete(id);
        }
    }
}
