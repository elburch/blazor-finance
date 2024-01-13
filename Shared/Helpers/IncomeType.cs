
using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Shared.Helpers
{
    public enum IncomeType
    {
        [Display(Name = "<None>")]
        None,
        [Display(Name = "Interest")]
        Interest,
        [Display(Name = "Dividend")]
        Dividend,
        [Display(Name = "Annuity")]
        Annuity,
        [Display(Name = "Pension")]
        Pension,
        [Display(Name = "Social Security")]
        SocialSecurity,
        [Display(Name = "Wages")]
        Wages,
        [Display(Name = "Withdrawal")]
        Withdrawal
    }
}
