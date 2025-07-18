﻿using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Shared.Types
{
    public enum InstitutionType
    {
        [Display(Name = "None Selected")]
        NoneSelected = -1,
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
        MortgageCompany,
        [Display(Name = "Federal")]
        Federal,
        [Display(Name = "City")]
        City,
        [Display(Name = "State")]
        State,
        [Display(Name = "Employer")]
        Employer
    }
}