using BlazorFinance.Shared.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Repositories
{
    public interface ITemplateRepository
    {
        public Task<BsonValue> CreateTemplateAsync(Template template);

        public Task<Template> ReadTemplateAsync(int id);

        public Task<List<Template>> ReadTemplateListAsync();

        public Task<List<Template>> ReadTemplateListAsync(Expression<Func<Template, bool>> predicate);

        public Task<bool> UpdateTemplateAsync(Template template);

        public Task<bool> DeleteTemplateAsync(BsonValue id);
    }
}
