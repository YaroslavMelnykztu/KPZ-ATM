using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Models;
using ATM.Services;
using ATM.Strategies;
using ATM.Factories;

namespace ATM.Services
{
    public class AuthService
    {
        private List<Account> _accounts;

        public AuthService()
        {
            _accounts = FileStorage.GetInstance().LoadAccounts();
        }

        public Account Login(string cardNumber, string pin)
        {
            var account = _accounts.FirstOrDefault(a => a.CardNumber == cardNumber && a.PinCode == pin);
            return account;
        }
    }
}
