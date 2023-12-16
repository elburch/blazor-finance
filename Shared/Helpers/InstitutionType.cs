using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Shared.Helpers
{
    public enum InstitutionType
    {
        [Display(Name = "Retail Bank")]
        RetailBank,
        [Display(Name = "Commercial Bank")]
        CommercialBank,
        [Display(Name = "Online Bank")]
        OnlineBank,
        [Display(Name = "Investment Bank")]
        InvestmentBank,
        [Display(Name = "Brokerage Firm")]
        BrokerageFirm,
        [Display(Name = "Credit Union")]
        CreditUnion,
        [Display(Name = "Insurance Company")]
        InsuranceCompany,
        [Display(Name = "Mortgage Company")]
        MortgageCompany
    }
}
