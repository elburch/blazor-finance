using BlazorFinance.Shared.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Repositories
{
    public interface IAssetRepository
    {
        public Task<BsonValue> CreateAssetAsync(Asset asset);

        public Task<Asset> ReadAssetAsync(int id);

        public Task<List<Asset>> ReadAssetListAsync();

        public Task<List<Asset>> ReadAssetListAsync(Expression<Func<Asset, bool>> predicate);

        public Task<bool> UpdateAssetAsync(Asset asset);

        public Task<int> UpdateAssetsAsync(List<Asset> assets);

        public Task<bool> DeleteAssetAsync(BsonValue id);
    }
}
