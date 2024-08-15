using BlazorFinance.Shared.Types;
using LiteDB;

namespace BlazorFinance.Shared.Entities
{
    public class Expense : IEntity
    {
        [BsonId]
        public int Id { get; set; }

        /// <summary>
        /// Expenses withdrawn directly from an Account
        /// BsonRef creates a reference between collections
        /// reference: https://www.litedb.org/docs/dbref/
        /// </summary>
        [BsonRef("account")]
        public Account? Account { get; set; } = new Account();

        /// <summary>
        /// Expense paid for by selling an owned asset
        /// BsonRef creates a reference between collections
        /// reference: https://www.litedb.org/docs/dbref/
        /// </summary>
        [BsonRef("asset")]
        public Asset? Asset { get; set; } = new Asset();

        public ExpenseType Type { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public Frequency Frequency { get; set; }

        public DateOnly StartingDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly EndingDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public Expense Clone()
        {
            return (Expense)this.MemberwiseClone();
        }
    }
}
