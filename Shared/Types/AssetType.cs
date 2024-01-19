using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BlazorFinance.Shared.Types
{
    public enum AssetType
    {
        [Display(Name = "<None>")]
        None = 0,

        // Liquid Assets
        [Display(Name = "Stock")]
        Stock = 1,
        [Display(Name = "Bond")]
        Bond = 2,
        [Display(Name = "Cash")]
        Cash = 3,
        [Display(Name = "Derivative")]
        Derivative = 4,
        [Display(Name = "Mutual Fund")]
        MutualFund = 5,
        [Display(Name = "Certificate of Deposit")]
        CertificateOfDeposit = 6,
        [Display(Name = "Commodity")]
        Commodity = 7,
        [Display(Name = "Cryptocurrency")]
        CryptoCurrency = 8,
        [Display(Name = "Exchange Traded Fund")]
        ExchangeTradedFund = 9,

        // Illiquid Assets
        [Display(Name = "Collectible")]
        Collectible = 100,
        [Display(Name = "Real Estate")]
        RealEstate = 101,
        [Display(Name = "Stock Options")]
        StockOptions = 102,
    }

    public static class AssetTypes
    {
        public static bool isLiquid(this AssetType asset)
        {
            return asset < AssetType.Collectible;
        }
        public static bool isIlliquid(this AssetType asset)
        {
            return asset >= AssetType.Collectible;
        }
    }
}
