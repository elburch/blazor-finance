using LiteDB;

namespace BlazorFinance.Server.Data
{
    public interface IDataContext<TEntity>
        where TEntity : class
    {
        public Task<List<TEntity>> Read();

        public Task<BsonValue> Create(TEntity entity);

        public Task<bool> Update(TEntity entity);

        public Task<bool> Delete(BsonValue id);
    }
}
