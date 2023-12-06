namespace BlazorFinance.Shared.Models
{
    public class StockModel
    {
        public int Id { get; set; }

        public int BrokerageId { get; set; }

        public string Symbol { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public decimal Quote { get; set; }

        public double Shares { get; set; }

        public decimal DayChange { get; set; }

        public decimal ChangePercentage { get; set; }

        public decimal Volume { get; set; }

        public decimal VolumeAvg { get; set; }

        public decimal MarketCap { get; set; }

        public decimal? PricePerEarningRatio { get; set; }

        public bool IsCategorized { get; set; }

        public IEnumerable<decimal> IntraDayChart { get; set; } = Enumerable.Empty<decimal>();
    }
}
