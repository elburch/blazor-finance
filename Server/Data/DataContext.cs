using BlazorFinance.Shared.Entities;
using LiteDB;

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

        public async Task<TEntity> Read(int Id)
        {
            try
            {
                using LiteDatabase db = new LiteDatabase(_dbpath);
                return await Task.Run(() => db
                     .GetCollection<TEntity>()
                     .Query()
                     .Where(x => x.Id == Id)
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
