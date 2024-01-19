using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFinance.Shared.Types
{
    public enum Frequency
    {
        [Display(Name = "Daily")]               // Daily
        Daily,
        [Display(Name = "Weekly")]              // Every week
        Weekly,
        [Display(Name = "BiWeekly")]            // Every other week
        BiWeekly,
        [Display(Name = "Semimonthly")]         // Twice a month
        SemiMonthly,
        [Display(Name = "Monthly")]             // Monthly
        Monthly,
        [Display(Name = "Quarterly")]           // Quarterly (four times of a Year)
        Quarterly,
        [Display(Name = "Semi Annually")]       // Every six months
        SemiAnnually,
        [Display(Name = "Annually")]            // Once a year
        Annually
    }
}
