using BlazorFinance.Server.Data;
using BlazorFinance.Shared.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private IDataContext<Income> _context;

        public IncomeRepository(IDataContext<Income> context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Income object
        /// </summary>
        /// <param name="Income"></param>
        /// <returns>BsonValue</returns>
        public async Task<BsonValue> CreateIncomeAsync(Income income)
        {
            return await _context.Create(income);
        }

        /// <summary>
        /// Reads a single Income object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Income</returns>
        public async Task<Income> ReadIncomeAsync(int id)
        {
            return await _context.Read(id);
        }

        /// <summary>
        /// Reads a list of Income objects matching predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List<Income></returns>
        public async Task<List<Income>> ReadIncomeListAsync(Expression<Func<Income, bool>> predicate)
        {
            return await _context.Read(predicate);
        }

        /// <summary>
        /// Reads a list of (all) Income objects
        /// </summary>
        /// <returns>List<Income></returns>
        public async Task<List<Income>> ReadIncomeListAsync()
        {
            return await _context.Read();
        }

        /// <summary>
        /// Updates an existing Income object
        /// </summary>
        /// <param name="Income"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateIncomeAsync(Income income)
        {
            return await _context.Update(income);
        }

        /// <summary>
        /// Deletes an Income object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteIncomeAsync(BsonValue id)
        {
            return await _context.Delete(id);
        }
    }
}
