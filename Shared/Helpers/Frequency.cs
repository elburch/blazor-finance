using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFinance.Shared.Helpers
{
    public enum Frequency
    {
        [Display(Name = "Daily")]
        Daily,
        [Display(Name = "Weekly")]
        Weekly,
        [Display(Name = "Monthly")]
        Monthly,
        [Display(Name = "Quarterly")]
        Quarterly,
        [Display(Name = "Semi Annually")]
        SemiAnnually,
        [Display(Name = "Annually")]
        Annually
    }
}
