using System.ComponentModel.DataAnnotations;

namespace BlazorFinance.Shared.Helpers
{
    public enum ExpenseType
    {
        [Display(Name = "<None>")]
        None,
        [Display(Name = "Mortgage")]
        Mortgage,
        [Display(Name = "Insurance")]
        Insurance,
        [Display(Name = "Taxes")]
        Taxes
    }
}
