using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Strategies
{
    public class DefaultCommission : ICommissionStrategy
    {
        public double Calculate(double amount)
        {
            return amount * 0.01;
        }
    }
}
