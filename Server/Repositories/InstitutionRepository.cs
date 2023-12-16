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
        /// Creates a new Institution object
        /// </summary>
        /// <param name="institution"></param>
        /// <returns>BsonValue</returns>
        public async Task<BsonValue> CreateInstitutionAsync(Institution institution)
        {
            return await _context.Create(institution);
        }

        /// <summary>
        /// Reads a single Institution objects
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Institution</returns>
        public async Task<Institution> ReadInstitutionAsync(int id)
        {
            return await _context.Read(id);
        }

        /// <summary>
        /// Reads a list of (all) Institution objects
        /// </summary>
        /// <returns>List<Institution></returns>
        public async Task<List<Institution>> ReadInstitutionListAsync()
        {
            return await _context.Read();
        }

        /// <summary>
        /// Updates an existing Institution object
        /// </summary>
        /// <param name="institution"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateInstitutionAsync(Institution institution)
        {
            return await _context.Update(institution);
        }

        /// <summary>
        /// Deletes an Institution object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteInstitutionAsync(BsonValue id)
        {
            return await _context.Delete(id);
        }
    }
}
