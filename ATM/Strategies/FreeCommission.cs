using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Strategies
{
    public class FreeCommission : ICommissionStrategy
    {
        public double Calculate(double amount)
        {
            return 0;
        }
    }
}
