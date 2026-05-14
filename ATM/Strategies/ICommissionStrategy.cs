using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Strategies
{
    public interface ICommissionStrategy
    {
        double Calculate(double amount);
    }
}