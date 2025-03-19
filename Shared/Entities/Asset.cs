using BlazorFinance.Shared.Types;
using LiteDB;

namespace BlazorFinance.Shared.Entities
{
    public class Asset : IEntity
    {
        [BsonId]
        public int Id { get; set; }

        public int AccountId { get; set; }

        public AssetType Type { get; set; }

        public string Symbol { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Quantity { get; set; }

        // Share Price
        public decimal Price { get; set; }

        // Quantity * Price
        public decimal MarketValue { get; set; }

        // Trailing Annual Dividend Rate
        public decimal DividendRate { get; set; }

        // Market Value at time of purchase
        public decimal CostBasis { get; set; }

        // Annual growth as percentage
        public double AnnualGrowth { get; set; }

        // Asset purchase date
        public DateOnly PurchaseDate { get; set; }

        // Asset sell date
        public DateOnly SellDate { get; set; } = DateOnly.MaxValue;

        // Timestamp of Price and Value metrics (as of)
        public DateTime SnapshotDate { get; set; } = DateTime.MinValue;

        public Asset Clone()
        {
            return (Asset)this.MemberwiseClone();
        }
    }
}
