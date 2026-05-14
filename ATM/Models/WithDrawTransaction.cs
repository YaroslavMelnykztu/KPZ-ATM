using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class WithdrawTransaction : BaseTransaction
    {
        public double Commission { get; set; }

        public override string GetDetails()
        {
            return "Withdrawal: " + Amount + " | Commission: " + Commission;
        }
    }
}
