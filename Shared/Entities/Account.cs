using BlazorFinance.Shared.Helpers;
using LiteDB;

namespace BlazorFinance.Shared.Entities
{
    public class Account : IEntity
    {
        [BsonId]
        public int Id { get; set; }
        public int InstitutionId { get; set; }
        public AccountType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }
}
