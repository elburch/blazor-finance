using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
