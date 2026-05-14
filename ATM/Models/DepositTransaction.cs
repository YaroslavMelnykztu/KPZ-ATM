using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class DepositTransaction : BaseTransaction
    {
        public override string GetDetails()
        {
            return "Deposit: " + Amount;
        }
    }
}
