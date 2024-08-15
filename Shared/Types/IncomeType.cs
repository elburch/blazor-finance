
using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Shared.Types
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
        Withdrawal,
        [Display(Name = "Asset Sale")]
        AssetSale,
        [Display(Name = "Miscellaneous")]
        Miscellaneous
    }

    public static class IncomeTypes
    {
        public static string ColorMap(this IncomeType income)
        {
            switch (income)
            {
                case IncomeType.None:
                    return "#ffffff";
                case IncomeType.Interest:
                    return "#1e001e";
                case IncomeType.Dividend:
                    return "#320032";
                case IncomeType.Annuity:
                    return "#450045";
                case IncomeType.Pension:
                    return "#590059";
                case IncomeType.SocialSecurity:
                    return "#6c006c";
                case IncomeType.Wages:
                    return "#800080";
                case IncomeType.Withdrawal:
                    return "#940094";
                case IncomeType.AssetSale:
                    return "#a700a7";
                case IncomeType.Miscellaneous:
                    return "#bb00bb";
                default:
                    return "#ffffff";

            }
        }
    }
}
