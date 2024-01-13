using BlazorFinance.Shared.Helpers;
using LiteDB;

namespace BlazorFinance.Shared.Entities
{
    public class Income : IEntity
    {
        [BsonId]
        public int Id { get; set; }

        /// <summary>
        /// Income received directly from an Institution
        /// (wages, pension, social security, etc.)
        /// BsonRef creates a reference between collections
        /// reference: https://www.litedb.org/docs/dbref/
        /// </summary>
        [BsonRef("institution")]
        public Institution? Institution { get; set; } = new Institution();

        /// <summary>
        /// Account that income will be deposited in
        /// BsonRef creates a reference between collections
        /// reference: https://www.litedb.org/docs/dbref/
        /// </summary>
        [BsonRef("account")]
        public Account? Account { get; set; } = new Account();

        /// <summary>
        /// Asset that income will be invested in
        /// BsonRef creates a reference between collections
        /// reference: https://www.litedb.org/docs/dbref/
        /// </summary>
        [BsonRef("asset")]
        public Asset? Asset { get; set; } = new Asset();

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public Frequency Frequency { get; set; }

        public DateOnly StartingDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly EndingDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
