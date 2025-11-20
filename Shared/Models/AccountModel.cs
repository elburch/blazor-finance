using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorFinance.Shared.Types;

namespace BlazorFinance.Shared.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public AccountType Type { get; set; }

        public double AnnualGrowth { get; set; }

        public string Name { get; set; } = String.Empty;

        public decimal Balance { get; set; }

        public decimal MarketValue { get; set; }
    }
}
