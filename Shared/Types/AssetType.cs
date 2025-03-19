using System.ComponentModel.DataAnnotations;

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

        public static string ColorMap(this AssetType asset)
        {
            switch (asset)
            {
                case AssetType.None:
                    return "#ffffff";
                case AssetType.Stock:
                    return "#1e001e";
                case AssetType.Bond:
                    return "#320032";
                case AssetType.Cash:
                    return "#450045";
                case AssetType.Derivative:
                    return "#590059";
                case AssetType.MutualFund:
                    return "#6c006c";
                case AssetType.CertificateOfDeposit:
                    return "#800080";
                case AssetType.Commodity:
                    return "#940094";
                case AssetType.CryptoCurrency:
                    return "#a700a7";
                case AssetType.ExchangeTradedFund:
                    return "#bb00bb";
                case AssetType.Collectible:
                    return "#ce00ce";
                case AssetType.RealEstate:
                    return "#e200e2";
                case AssetType.StockOptions:
                    return "#f600f6";
                default: 
                    return "#ffffff";
            }
        }
    }
}
