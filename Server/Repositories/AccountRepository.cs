using BlazorFinance.Server.Data;
using BlazorFinance.Shared.Entities;
using LiteDB;

namespace BlazorFinance.Server.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private IDataContext<Account> _context;

        public AccountRepository(IDataContext<Account> context)
        {
            _context = context;

            var mapper = BsonMapper.Global;

            mapper.Entity<Account>()
                .DbRef(x => x.Institution, "institution");
        }

        /// <summary>
        /// Creates a new Account object
        /// </summary>
        /// <param name="Account"></param>
        /// <returns>BsonValue</returns>
        public async Task<BsonValue> CreateAccountAsync(Account account)
        {
            return await _context.Create(account);
        }

        /// <summary>
        /// Reads a single Account object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Account</returns>
        public async Task<Account> ReadAccountAsync(int id)
        {
            return await _context.Read(id);
        }

        /// <summary>
        /// Reads a list of (all) Account objects
        /// </summary>
        /// <returns>List<Account></returns>
        public async Task<List<Account>> ReadAccountListAsync()
        {
            return await _context.Read(e => e.Institution != null, "Institution");
        }

        /// <summary>
        /// Updates an existing Account object
        /// </summary>
        /// <param name="Account"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateAccountAsync(Account account)
        {
            return await _context.Update(account);
        }

        /// <summary>
        /// Deletes an Account object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteAccountAsync(BsonValue id)
        {
            return await _context.Delete(id);
        }
    }
}
