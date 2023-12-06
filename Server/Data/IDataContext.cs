using LiteDB;

namespace BlazorFinance.Server.Data
{
    public interface IDataContext<TEntity>
        where TEntity : class
    {
        public Task<List<TEntity>> Get();

        public Task<BsonValue> Insert(TEntity entity);

        public Task<bool> Update(TEntity entity);
    }
}
