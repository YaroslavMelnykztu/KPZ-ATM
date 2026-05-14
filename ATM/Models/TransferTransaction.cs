using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class TransferTransaction : BaseTransaction
    {
        public string TargetCard { get; set; }

        public override string GetDetails()
        {
            return "Transfer: " + Amount + " to card " + TargetCard;
        }
    }
}
