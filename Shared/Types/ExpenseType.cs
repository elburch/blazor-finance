using BlazorFinance.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Shared.Types
{
    public enum ExpenseType
    {
        [Display(Name = "<None>")]
        None,
        [Display(Name = "Child Care")]
        ChildCare,
        [Display(Name = "Debt")]
        Debt,
        [Display(Name = "Education")]
        Education,
        [Display(Name = "Food")]
        Food,
        [Display(Name = "Housing")]
        Housing,
        [Display(Name = "Insurance")]
        Insurance,
        [Display(Name = "Leisure & Entertainment")]
        LeisureEntertainment,
        [Display(Name = "Personal Care")]
        PersonalCare,
        [Display(Name = "Savings")]
        Savings,
        [Display(Name = "Taxes")]
        Taxes,
        [Display(Name = "Transportation")]
        Transportation,
        [Display(Name = "Utilities")]
        Utilities,
        [Display(Name = "Miscellaneous")]
        Miscellaneous
    }

    public static class ExpenseTypes
    {
        public static string ColorMap(this ExpenseType expense)
        { 
            switch (expense)
            {
                case ExpenseType.None:
                    return "#ffffff";
                case ExpenseType.ChildCare:
                    return "#d7a1f9";
                    case ExpenseType.Debt:
                    return "#ce8cf8";
                case ExpenseType.Education:
                    return "#c576f6";
                case ExpenseType.Food:
                    return "#bc61f5";
                case ExpenseType.Housing:
                    return "#b24bf3";
                case ExpenseType.Insurance:
                    return "#a020f0";
                case ExpenseType.LeisureEntertainment:
                    return "#9417e2";
                case ExpenseType.PersonalCare:
                    return "#880ed4";
                case ExpenseType.Savings:
                    return "#7921b1";
                case ExpenseType.Taxes:
                    return "#692d94";
                case ExpenseType.Transportation:
                    return "#613385";
                case ExpenseType.Utilities:
                    return "#6c0ba9";
                case ExpenseType.Miscellaneous:
                    return "#593876";
                default:
                    return "#ffffff";

                    //additional colors in sequence
                    //#51087e
                    //#461257
                    //#3a1b2f

            }
        }
    }
}
