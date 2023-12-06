using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFinance.Shared.Models
{
    public class AssetModel
    {
        public int Id { get; set; }

        public int AssetTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal CostBasis { get; set; }

        public decimal MarketValue { get; set; }

        public DateOnly PurchaseDate { get; set; }
    }
}
