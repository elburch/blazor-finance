using BlazorFinance.Shared.Helpers;
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

        public double Quantity { get; set; }

        // Share Price
        public decimal Price { get; set; }

        // Quantity * Price
        public decimal MarketValue { get; set; }

        // Market Value at time of purchase
        public decimal CostBasis { get; set; }

        // Annual growth as percentage - how will this be factored into projections?
        public double AnnualGrowth { get; set; }

        // Asset purchase date
        public DateOnly PurchaseDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        // Timestamp of Price and Value metrics (as of)
        public DateTime SnapshotDate { get; set; } = DateTime.Now;
    }
}
