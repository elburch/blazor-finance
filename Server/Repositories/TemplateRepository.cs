using BlazorFinance.Server.Data;
using BlazorFinance.Shared.Entities;
using LiteDB;
using System.Linq.Expressions;

namespace BlazorFinance.Server.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private IDataContext<Template> _context;

        public TemplateRepository(IDataContext<Template> context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Template object
        /// </summary>
        /// <param name="Template"></param>
        /// <returns>BsonValue</returns>
        public async Task<BsonValue> CreateTemplateAsync(Template template)
        {
            return await _context.Create(template);
        }

        /// <summary>
        /// Reads a single Template object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Template</returns>
        public async Task<Template> ReadTemplateAsync(int id)
        {
            return await _context.Read(id);
        }

        /// <summary>
        /// Reads a list of Template objects matching predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List<Template></returns>
        public async Task<List<Template>> ReadTemplateListAsync(Expression<Func<Template, bool>> predicate)
        {
            return await _context.Read(predicate);
        }

        /// <summary>
        /// Reads a list of (all) Template objects
        /// </summary>
        /// <returns>List<Template></returns>
        public async Task<List<Template>> ReadTemplateListAsync()
        {
            return await _context.Read();
        }

        /// <summary>
        /// Updates an existing Template object
        /// </summary>
        /// <param name="Template"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateTemplateAsync(Template template)
        {
            return await _context.Update(template);
        }

        /// <summary>
        /// Deletes an Template object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteTemplateAsync(BsonValue id)
        {
            return await _context.Delete(id);
        }
    }
}
