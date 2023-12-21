using BlazorFinance.Shared.Helpers;

namespace BlazorFinance.Shared.Entities
{
    public class Asset : IEntity
    {
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

        // Asset purchase date
        public DateOnly PurchaseDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        // Market Value at time of purchase
        public decimal CostBasis { get; set; }

        // Timestamp of Price and Value metrics (as of)
        public DateTime SnapshotDate { get; set; } = DateTime.Now;
    }
}
