using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Account
    {
        public string CardNumber { get; set; }
        public string PinCode { get; set; }
        public double Balance { get; set; }
        public string OwnerName { get; set; }
    }
}
