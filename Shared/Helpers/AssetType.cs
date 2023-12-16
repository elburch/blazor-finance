using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Shared.Enums
{
    public enum AssetType
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Stock")]
        Stock,
        [Display(Name = "Bond")]
        Bond,
        [Display(Name = "Cash")]
        Cash,
        [Display(Name = "Real Estate")]
        RealEstate,
        [Display(Name = "Derivative")]
        Derivative,
        [Display(Name = "Mutual Fund")]
        MutualFund,
        [Display(Name = "Certificate of Deposit")]
        CertificateOfDeposit,
        [Display(Name = "Commodity")]
        Commodity,
        [Display(Name = "Cryptocurrency")]
        CryptoCurrency,
        [Display(Name = "Exchange Traded Fund")]
        ExchangeTradedFund
    }
}
