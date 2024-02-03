using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFinance.Shared.Models
{
    public class ProjectionModel
    {
        public int CurrentAge { get; set; }

        public int ExpirationAge { get; set; }

        public decimal AnnualInflation { get; set; }
    }
}
