using BlazorFinance.Shared.Helpers;
using LiteDB;

namespace BlazorFinance.Shared.Entities
{
    public class Income : IEntity
    {
        [BsonId]
        public int Id { get; set; }

        /// <summary>
        /// BsonRef creates a reference between collections
        /// reference: https://www.litedb.org/docs/dbref/
        /// </summary>
        [BsonRef("account")]
        public Account? Account { get; set; } = new Account();

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public Frequency Frequency { get; set; }

        public DateOnly StartingDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly EndingDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
