using BlazorFinance.Server.Data;
using BlazorFinance.Shared.Entities;
using LiteDB;

namespace BlazorFinance.Server.Repositories
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private IDataContext<Institution> _context;

        public InstitutionRepository(IDataContext<Institution> context) 
        {
            _context = context;
        }

        /// <summary>
        /// Gets a list of (all) Institution objects
        /// </summary>
        /// <returns></returns>
        public async Task<List<Institution>> GetInstitutionListAsync()
        {
            return await _context.Get();
        }

        /// <summary>
        /// Returns a BsonValue representing the institution Id
        /// </summary>
        /// <param name="institution"></param>
        /// <returns>BsonValue</returns>
        public async Task<BsonValue> InsertInstitutionAsync(Institution institution)
        {
            return await _context.Insert(institution);
        }

        public async Task<bool> UpdateInstitutionAsync(Institution institution)
        {
            return await _context.Update(institution);
        }
    }
}
