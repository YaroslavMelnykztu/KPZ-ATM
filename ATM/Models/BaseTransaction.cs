using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public abstract class BaseTransaction
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public abstract string GetDetails();
    }
}
