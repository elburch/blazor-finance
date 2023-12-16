using BlazorFinance.Shared.Entities;
using LiteDB;

namespace BlazorFinance.Server.Repositories
{
    public interface IAccountRepository
    {
        public Task<BsonValue> CreateAccountAsync(Account account);

        public Task<Account> ReadAccountAsync(int id);

        public Task<List<Account>> ReadAccountListAsync();

        public Task<bool> UpdateAccountAsync(Account account);

        public Task<bool> DeleteAccountAsync(BsonValue id);
    }
}
