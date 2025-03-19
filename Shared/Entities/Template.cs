using BlazorFinance.Shared.Types;
using LiteDB;

namespace BlazorFinance.Shared.Entities
{
    public class Template : IEntity
    {
        [BsonId]
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public AssetType Type { get; set; } = AssetType.None;

        public string TickerLabel { get; set; } = String.Empty;

        public string DescriptionLabel { get; set; } = String.Empty;

        public string SharesLabel { get; set; } = String.Empty;

        public string PriceLabel { get; set; } = String.Empty;


    }
}
