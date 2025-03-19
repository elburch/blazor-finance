using BlazorFinance.Shared.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Data
{
    public  class DataContext<TEntity> : IDataContext<TEntity>
        where TEntity : class, IEntity
    {
        private static string? _dbpath;

        /// <summary>
        /// A static constructor initializes the class before the first instance is created
        /// Reference: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
        /// </summary>
        static DataContext()
        {
            _dbpath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\PortfolioManager\\portfolio.db";

            if (!Directory.Exists(Path.GetDirectoryName(_dbpath))) {
                Directory.CreateDirectory(Path.GetDirectoryName(_dbpath) ?? string.Empty);
            }

            if (!File.Exists(_dbpath)) {
                using FileStream fs = File.Create(_dbpath);
                fs.Close();
            }


            //        LiteException: Cannot insert duplicate key in unique index 'idx_account_name'.The duplicate value is 'null'.
            //LiteDB.Engine.IndexService.AddNode(CollectionIndex index, BsonValue key, PageAddress dataBlock, byte level, IndexNode last)
            //LiteDB.Engine.IndexService.AddNode(CollectionIndex index, BsonValue key, PageAddress dataBlock, IndexNode last)
            //LiteDB.Engine.LiteEngine +<> c__DisplayClass5_0.< EnsureIndex > b__0(TransactionService transaction)
            //LiteDB.Engine.LiteEngine.AutoTransaction<T>(Func < TransactionService, T > fn)
            //LiteDB.Engine.LiteEngine.EnsureIndex(string collection, string name, BsonExpression expression, bool unique)
            //BlazorFinance.Server.Data.DataContext < TEntity > ..cctor() in DataContext.cs
            //+
            //                engine.EnsureIndex("Account", "idx_account_name", "$.Account.Name", true);


            //using (LiteEngine engine = new LiteEngine(_dbpath))
            //{
            //    engine.EnsureIndex("Account", "idx_account_name", "$.Account.Name", true);
            //    engine.EnsureIndex("Asset", "idx_asset_description", "$.Asset.Description", true);
            //    engine.EnsureIndex("Expense", "idx_expense_description", "$.Expense.Description", true);
            //    engine.EnsureIndex("Institution", "idx_institution_name", "$.Institution.Name", true);
            //}
        }

        public async Task<BsonValue> Create(TEntity entity)
        {
            try
            {
                using LiteDatabase db = new LiteDatabase(_dbpath);
                return await Task.Run(() => db
                    .GetCollection<TEntity>()
                    .Insert(entity));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An exception occurred while attempting to insert the new {nameof(TEntity)} record.  Message: {ex.Message}"
                );
            }
        }

        public async Task<TEntity> Read(int Id)
        {
            try
            {
                using LiteDatabase db = new LiteDatabase(_dbpath);
                return await Task.Run(() => db
                     .GetCollection<TEntity>()
                     .Query()
                     .Where(e => e.Id == Id)
                     .FirstOrDefault()
                 );
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An exception occurred while attempting to get {nameof(TEntity)} record {Id}.  Message: {ex.Message}"
                );
            }
        }

        public async Task<List<TEntity>> Read()
        {
            try
            {
                using LiteDatabase db = new LiteDatabase(_dbpath);
                return await Task.Run(() => db
                     .GetCollection<TEntity>()
                     .Query()
                     .ToList()
                 );
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An exception occurred while attempting to get {nameof(TEntity)} records.  Message: {ex.Message}"
                );
            }
        }

        /// <summary>
        /// Use to include a where clause and related tables
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<TEntity>> Read(BsonExpression expression)
        {
            List<TEntity> entities;

            try
            {
                using (LiteDatabase db = new LiteDatabase(_dbpath))
                {
                    ILiteQueryable<TEntity> query = await Task.Run(() => db
                        .GetCollection<TEntity>()
                        .Query()
                    );

                    entities = query.Include(expression).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An exception occurred while attempting to get {nameof(TEntity)} records.  Message: {ex.Message}"
                );
            }

            return entities;
        }

        /// <summary>
        /// Use to include a where clause and related tables
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<TEntity>> Read(Expression<Func<TEntity, bool>> predicate, params string[] properties)
        {
            List<TEntity> entities;

            try
            {
                using (LiteDatabase db = new LiteDatabase(_dbpath))
                {
                    ILiteQueryable<TEntity> query = await Task.Run(() => db
                        .GetCollection<TEntity>()
                        .Query()
                    );

                    foreach (var property in properties)
                        query = query.Include(property);

                    entities = query
                        .Where(predicate)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An exception occurred while attempting to get {nameof(TEntity)} records.  Message: {ex.Message}"
                );
            }

            return entities;
        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                using LiteDatabase db = new LiteDatabase(_dbpath);
                return await Task.Run(() => db
                    .GetCollection<TEntity>()
                    .Update(entity));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An exception occurred while attempting to update {nameof(TEntity)} record {entity.Id}.  Message: {ex.Message}"
                );
            }
        }

        public async Task<int> Update(IEnumerable<TEntity> entities)
        {
            try
            {
                using LiteDatabase db = new LiteDatabase(_dbpath);
                return await Task.Run(() => db
                    .GetCollection<TEntity>()
                    .Update(entities));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An exception occurred while attempting to batch update {nameof(TEntity)} records.  Message: {ex.Message}"
                );
            }
        }

        public async Task<bool> Upsert(TEntity entity)
        {
            try
            {
                using LiteDatabase db = new LiteDatabase(_dbpath);
                return await Task.Run(() => db
                    .GetCollection<TEntity>()
                    .Upsert(entity));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An exception occurred while attempting to upsert the {nameof(TEntity)} record.  Message: {ex.Message}"
                );
            }
        }

        public async Task<bool> Delete(BsonValue Id)
        {
            try
            {
                using LiteDatabase db = new LiteDatabase(_dbpath);
                return await Task.Run(() => db
                    .GetCollection<TEntity>()
                    .Delete(Id));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An exception occurred while attempting to delete {nameof(TEntity)} record {Id}.  Message: {ex.Message}"
                );
            }
        }
    }
}
