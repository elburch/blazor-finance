using LiteDB;

namespace BlazorFinance.Server.Domain
{
    public class StockRecord
    {
        public ObjectId Id { get; set; } = ObjectId.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Shares { get; set; }
    }
}
