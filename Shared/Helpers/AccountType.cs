using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Shared.Helpers
{
    public enum AccountType
    {
        [Display(Name ="<None>")]
        None,
        [Display(Name = "Cash")]
        Cash,
        [Display(Name = "Savings")]
        Savings,
        [Display(Name = "Discount")]
        Checking,
        [Display(Name = "Checking")]
        Discount,
        [Display(Name = "Education")]
        Education,
        [Display(Name = "Full Service")]
        FullService,
        [Display(Name = "Margin")]
        Margin,
        [Display(Name = "Option")]
        Option,
        [Display(Name = "Robo-Advisor")]
        RoboAdvisor,
        [Display(Name = "Roth IRA")]
        RothIRA,
        [Display(Name = "Traditional IRA")]
        TraditionalIRA,
        [Display(Name = "Roth 401K")]
        Roth401K,
        [Display(Name = "Traditional 401K")]
        Traditional401K,
        [Display(Name = "Pension")]
        Pension,
        [Display(Name = "Social Security")]
        SocialSecurity,
        [Display(Name = "Mortgage")]
        Mortgage
    }
}
