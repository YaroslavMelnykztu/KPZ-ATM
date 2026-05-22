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
        private PasswordHasher _hasher;

        public AuthService()
        {
            _accounts = FileStorage.GetInstance().LoadAccounts();
            _hasher = new PasswordHasher();
        }

        public Account Login(string cardNumber, string pin)
        {
            var account = _accounts.FirstOrDefault(a => a.CardNumber == cardNumber);
            if (account != null && _hasher.VerifyPassword(pin, account.PinCode))
            {
                return account;
            }
            return null;
        }
    }
}
