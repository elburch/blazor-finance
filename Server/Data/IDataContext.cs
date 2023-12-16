using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Data
{
    public interface IDataContext<TEntity>
        where TEntity : class
    {
        public Task<BsonValue> Create(TEntity entity);

        public Task<TEntity> Read(int id);

        public Task<List<TEntity>> Read();

        public Task<List<TEntity>> Read(Expression<Func<TEntity, bool>> predicate, params string[] properties);

        public Task<bool> Update(TEntity entity);

        public Task<bool> Delete(BsonValue id);
    }
}
