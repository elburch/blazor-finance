﻿using BlazorFinance.Shared.Entities;
using LiteDB;

namespace BlazorFinance.Server.Repositories
{
    public interface IInstitutionRepository
    {
        public Task<BsonValue> CreateInstitutionAsync(Institution institution);

        public Task<Institution> ReadInstitutionAsync(int id);

        public Task<List<Institution>> ReadInstitutionListAsync();

        public Task<bool> UpdateInstitutionAsync(Institution institution);

        public Task<bool> DeleteInstitutionAsync(BsonValue id);
    }
}
