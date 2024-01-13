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

        /// <summary>
        /// Monetary Accounts (i.e. Savings, Checking, etc.)
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Annual growth as percentage
        /// </summary>
        public double AnnualGrowth { get; set; }
    }
}
