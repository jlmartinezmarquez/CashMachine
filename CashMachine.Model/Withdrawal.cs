using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Model
{
    public class Withdrawal
    {
        public List<Item> WithdrawnItems { get; set; }

        public double BalanceAfter { get; set; }
    }
}
