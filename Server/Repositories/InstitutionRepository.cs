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
        /// Returns a BsonValue representing the institution Id
        /// </summary>
        /// <param name="institution"></param>
        /// <returns>BsonValue</returns>
        public async Task<BsonValue> CreateInstitutionAsync(Institution institution)
        {
            return await _context.Create(institution);
        }

        /// <summary>
        /// Reads a list of (all) Institution objects
        /// </summary>
        /// <returns></returns>
        public async Task<List<Institution>> ReadInstitutionListAsync()
        {
            return await _context.Read();
        }

        public async Task<bool> UpdateInstitutionAsync(Institution institution)
        {
            return await _context.Update(institution);
        }

        public async Task<bool> DeleteInstitutionAsync(BsonValue id)
        {
            return await _context.Delete(id);
        }
    }
}
