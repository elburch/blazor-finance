using BlazorFinance.Server.Data;
using BlazorFinance.Shared.Entities;
using LiteDB;

namespace BlazorFinance.Server.Repositories
{
    public interface IInstitutionRepository
    {
        public Task<List<Institution>> GetInstitutionListAsync();

        public Task<BsonValue> InsertInstitutionAsync(Institution institution);

        public Task<bool> UpdateInstitutionAsync(Institution institution);
    }
}
