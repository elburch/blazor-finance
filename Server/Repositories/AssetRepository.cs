using BlazorFinance.Server.Data;
using BlazorFinance.Shared.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private IDataContext<Asset> _context;

        public AssetRepository(IDataContext<Asset> context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Asset object
        /// </summary>
        /// <param name="Asset"></param>
        /// <returns>BsonValue</returns>
        public async Task<BsonValue> CreateAssetAsync(Asset asset)
        {
            return await _context.Create(asset);
        }

        /// <summary>
        /// Reads a single Asset object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Asset</returns>
        public async Task<Asset> ReadAssetAsync(int id)
        {
            return await _context.Read(id);
        }

        /// <summary>
        /// Reads a list of Asset objects matching predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List<Asset></returns>
        public async Task<List<Asset>> ReadAssetListAsync(Expression<Func<Asset, bool>> predicate)
        {
            return await _context.Read(predicate);
        }

        /// <summary>
        /// Reads a list of (all) Asset objects
        /// </summary>
        /// <returns>List<Asset></returns>
        public async Task<List<Asset>> ReadAssetListAsync()
        {
            return await _context.Read();
        }

        /// <summary>
        /// Updates an existing Asset object
        /// </summary>
        /// <param name="Asset"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateAssetAsync(Asset asset)
        {
            return await _context.Update(asset);
        }

        /// <summary>
        /// Updates a list of Asset objects
        /// </summary>
        /// <param name="assets"></param>
        /// <returns></returns>
        public async Task<int> UpdateAssetsAsync(List<Asset> assets)
        {
            return await _context.Update(assets);
        }

        /// <summary>
        /// Upserts an Asset object
        /// </summary>
        /// <param name="Asset"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpsertAssetAsync(Asset asset)
        {
            return await _context.Upsert(asset);
        }

        /// <summary>
        /// Deletes an Asset object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteAssetAsync(BsonValue id)
        {
            return await _context.Delete(id);
        }
    }
}
